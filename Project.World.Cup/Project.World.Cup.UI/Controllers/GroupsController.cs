using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.World.Cup.Data;
using Project.World.Cup.Model;

namespace Project.World.Cup.UI.Controllers
{
    public class GroupsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GroupsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var result = _context.Groups
                .Include(g => g.Tournament)
                .Include(g => g.GroupTeams)
                .ToList();

            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["TournamentId"] = new SelectList(
                _context.Tournaments.ToList(),
                "TournamentId",
                "TournamentName"
                );
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Group group)
        {
            if (ModelState.IsValid)
            {
                _context.Groups.Add(group);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewData["TournamentId"] = new SelectList(
                _context.Tournaments.ToList(),
                "TournamentId",
                "TournamentName",
                group.TournamentId
                );

            return View(group);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var group = _context.Groups.Find(id);

            if(group == null)
            {
                return NotFound();
            }

            ViewData["TournamentId"] = new SelectList(
                _context.Tournaments.ToList(),
                "TournamentId",
                "TournamentName",
                group.TournamentId
                );

            return View(group);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Group group)
        {
            if(id != group.GroupId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Groups.Update(group);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewData["TournamentId"] = new SelectList(
                _context.Tournaments.ToList(),
                "TournamentId",
                "TournamentName",
                group.TournamentId
                );

            return View(group);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var group = _context.Groups
                .Include(g => g.Tournament)
                .FirstOrDefault(g => g.GroupId == id);

            if(group == null)
            {
                return NotFound();
            }

            return View(group);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Group group)
        {
            if (group != null)
            {
                _context.Groups.Remove(group);
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
                match?.HomeTeamId
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
