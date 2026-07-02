using Microsoft.AspNetCore.Mvc;
using Project.World.Cup.Data;
using Project.World.Cup.Model;

namespace Project.World.Cup.UI.Controllers
{
    public class TournamentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TournamentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var result = _context.Tournaments.ToList();
            return View(result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Tournament tournament)
        {
            _context.Add(tournament);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var result = _context.Tournaments.Find(id);
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(Tournament tournament)
        {
            _context.Update(tournament);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var result = _context.Tournaments.Find(id);
            return View(result);
        }

        [HttpPost]
        public IActionResult Delete(Tournament tournament)
        {
            _context.Tournaments.Remove(tournament);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
