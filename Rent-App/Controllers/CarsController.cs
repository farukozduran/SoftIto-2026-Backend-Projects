using Microsoft.AspNetCore.Mvc;
using Rent.App.Models;

namespace Rent.App.Controllers
{
    public class CarsController : Controller
    {
        public readonly AppDbContext _context;

        public CarsController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string search, bool isAdmin = false)
        {
            var result = _context.Cars.AsQueryable();

            if(!string.IsNullOrEmpty(search))
            {
                result = result.Where(x =>
                    x.Brand.Contains(search) ||
                    x.Model.Contains(search) ||
                    x.Plate.Contains(search)
                );
            }

            ViewData["IsAdmin"] = isAdmin;

            ViewData["CurrentSearch"] = search;
            return View(result.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Car car)
        {
            _context.Add(car);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var result = _context.Cars.Find(id);
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(Car car)
        {
            _context.Update(car);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var result = _context.Cars.Find(id);
            return View(result);
        }
        [HttpPost]
        public IActionResult Delete(int id, Car car)
        {
            _context.Cars.Remove(car);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
