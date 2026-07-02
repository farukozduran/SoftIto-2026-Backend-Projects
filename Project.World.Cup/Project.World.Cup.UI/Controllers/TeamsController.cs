using Microsoft.AspNetCore.Mvc;
using Project.World.Cup.Data;
using Project.World.Cup.Model;
using System.ComponentModel.DataAnnotations;

namespace Project.World.Cup.UI.Controllers
{
    public class TeamsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TeamsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var result = _context.Teams.ToList();
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Team team)
        {
            _context.Add(team);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var result = _context.Teams.Find(id);
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(Team team)
        {
            _context.Update(team);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var result = _context.Teams.Find(id);
            return View(result);
        }

        [HttpPost]
        public IActionResult Delete(Team team)
        {
            _context.Teams.Remove(team);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
