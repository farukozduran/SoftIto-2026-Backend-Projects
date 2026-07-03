using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.World.Cup.Data;
using Project.World.Cup.Model;

namespace Project.World.Cup.UI.Controllers
{
    public class MatchEventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MatchEventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var result = _context.MatchEvents
                .Include(m => m.Match)
                    .ThenInclude(m => m.HomeTeam)
                .Include(m => m.Match)
                    .ThenInclude(m => m.AwayTeam)
                .Include(m => m.Team)
                .OrderBy(m => m.MatchId).ThenBy(m => m.EventMinute)
                .ToList();

            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreateSelectLists();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MatchEvent matchEvent)
        {
            ModelState.Remove("Match");
            ModelState.Remove("Team");

            if (ModelState.IsValid)
            {
                _context.MatchEvents.Add(matchEvent);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            CreateSelectLists(matchEvent);
            return View(matchEvent);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            var matchEvent = _context.MatchEvents.Find(id);
            if (matchEvent == null) return NotFound();

            CreateSelectLists(matchEvent);
            return View(matchEvent);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, MatchEvent matchEvent)
        {
            if (id != matchEvent.MatchEventId) return NotFound();

            ModelState.Remove("Match");
            ModelState.Remove("Team");

            if (ModelState.IsValid)
            {
                _context.MatchEvents.Update(matchEvent);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            CreateSelectLists(matchEvent);
            return View(matchEvent);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            var matchEvent = _context.MatchEvents
                .Include(m => m.Match)
                .Include(m => m.Team)
                .FirstOrDefault(m => m.MatchEventId == id);

            if (matchEvent == null) return NotFound();

            return View(matchEvent);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var matchEvent = _context.MatchEvents.Find(id);
            if (matchEvent != null)
            {
                _context.MatchEvents.Remove(matchEvent);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        private void CreateSelectLists(MatchEvent? matchEvent = null)
        {
            var matches = _context.Matches
                .Include(m => m.HomeTeam)
                .Include(m => m.AwayTeam)
                .Select(m => new
                {
                    MatchId = m.MatchId,
                    MatchName = $"{(m.HomeTeam != null ? m.HomeTeam.TeamName : "")} - {(m.AwayTeam != null ? m.AwayTeam.TeamName : "")} ({m.MatchDate:dd.MM.yyyy})"
                }).ToList();

            ViewData["MatchId"] = new SelectList(matches, "MatchId", "MatchName", matchEvent?.MatchId);

            ViewData["TeamId"] = new SelectList(_context.Teams.ToList(), "TeamId", "TeamName", matchEvent?.TeamId);

            ViewData["EventType"] = new SelectList(
                new List<string> { "Goal", "Yellow Card", "Red Card", "Substitution", "Penalty Missed", "Own Goal", "VAR Decision" },
                matchEvent?.EventType
            );
        }
    }
}
