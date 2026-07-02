using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.World.Cup.Data;
using Project.World.Cup.Model;

namespace Project.World.Cup.UI.Controllers
{
    public class MatchesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MatchesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var result = _context.Matches
                .Include(m => m.HomeTeam)
                .Include(m => m.AwayTeam)
                .Include(m => m.Stadium)
                .Include(m => m.Group)
                .Include(m => m.Tournament)
                .OrderBy(m => m.MatchDate)
                .ToList();

            return View(result);
        }

       [HttpGet]
        public IActionResult Create()
        {
            ViewData["TeamId"] = new SelectList(
                _context.Matches.ToList(),
                "TeamId",
                "TeamName"
                );
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Match match)
        {
            ModelState.Remove("Tournament");
            ModelState.Remove("Group");
            ModelState.Remove("Stadium");
            ModelState.Remove("HomeTeam");
            ModelState.Remove("AwayTeam");
            ModelState.Remove("MatchEvents");

            if (match.HomeTeamId != null && match.AwayTeamId != null && match.HomeTeamId == match.AwayTeamId)
            {
                ModelState.AddModelError("AwayTeamId", "Ev sahibi takım ve deplasman takımı aynı olamaz.");
            }

            if (ModelState.IsValid)
            {
                _context.Matches.Add(match);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            CreateSelectLists(match);
            return View(match);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var match = _context.Matches.Find(id);

            if(match == null)
            {
                return NotFound();
            }

            CreateSelectLists(match);
            return View(match);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Match match)
        {
            if (id != match.MatchId)
            {
                return NotFound();
            }

            ModelState.Remove("Tournament");
            ModelState.Remove("Group");
            ModelState.Remove("Stadium");
            ModelState.Remove("HomeTeam");
            ModelState.Remove("AwayTeam");
            ModelState.Remove("MatchEvents");

            if (match.HomeTeamId != null && match.AwayTeamId != null && match.HomeTeamId == match.AwayTeamId)
            {
                ModelState.AddModelError("AwayTeamId", "Ev sahibi takım ve deplasman takımı aynı olamaz.");
            }

            if (ModelState.IsValid)
            {
                _context.Matches.Update(match);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            CreateSelectLists(match);
            return View(match);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match = _context.Matches
                .Include(m => m.HomeTeam)
                .Include(m => m.AwayTeam)
                .Include(m => m.Stadium)
                .Include(m => m.Group)
                .Include(m => m.Tournament)
                .FirstOrDefault(m => m.MatchId == id);

            if (match == null)
            {
                return NotFound();
            }

            return View(match);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var match = _context.Matches.Find(id);

            if (match != null)
            {
                _context.Matches.Remove(match);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        private void CreateSelectLists(Match? match = null)
        {
            ViewData["TournamentId"] = new SelectList(
                _context.Tournaments.OrderBy(t => t.TournamentName).ToList(),
                "TournamentId",
                "TournamentName",
                match?.TournamentId
            );

            ViewData["GroupId"] = new SelectList(
                _context.Groups.OrderBy(g => g.GroupName).ToList(),
                "GroupId",
                "GroupName",
                match?.GroupId
            );

            ViewData["StadiumId"] = new SelectList(
                _context.Stadiums.OrderBy(s => s.StadiumName).ToList(),
                "StadiumId",
                "StadiumName",
                match?.StadiumId
            );

            ViewData["HomeTeamId"] = new SelectList(
                _context.Teams.OrderBy(t => t.TeamName).ToList(),
                "TeamId",
                "TeamName",
                match?.HomeTeamId
            );

            ViewData["AwayTeamId"] = new SelectList(
                _context.Teams.OrderBy(t => t.TeamName).ToList(),
                "TeamId",
                "TeamName",
                match?.AwayTeamId
            );

            ViewData["MatchStage"] = new SelectList(
                new List<string>
                {
                    "Group",
                    "Round of 32",
                    "Round of 16",
                    "Quarter Final",
                    "Semi Final",
                    "Third Place",
                    "Final"
                },
                match?.MatchStage
            );

            ViewData["MatchStatus"] = new SelectList(
                new List<string>
                {
                    "Scheduled",
                    "Live",
                    "Finished",
                    "Postponed",
                    "Cancelled"
                },
                match?.MatchStatus
            );
        }
    }
}
