using Microsoft.AspNetCore.Mvc;
using Project.World.Cup.Data;
using Project.World.Cup.Model;

namespace Project.World.Cup.UI.Controllers
{
    public class StadiumsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StadiumsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var result = _context.Stadiums.ToList();
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Stadium stadium)
        {
            _context.Add(stadium);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var result = _context.Stadiums.Find(id);
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(Stadium stadium)
        {
            _context.Update(stadium);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var result = _context.Stadiums.Find(id);
            return View(result);
        }
        [HttpPost]
        public IActionResult Delete(Stadium stadium)
        {
            _context.Stadiums.Remove(stadium);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
