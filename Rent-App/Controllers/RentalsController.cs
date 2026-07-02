using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rent.App.Models;

namespace Rent.App.Controllers
{
    public class RentalsController : Controller
    {
        public readonly AppDbContext _context;

        public RentalsController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string search, bool isAdmin = false)
        {
            var result = _context.Rentals
                .Include(x => x.Customer)
                .Include(x => x.Car)
                .AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                result = result.Where(x =>
                    x.Customer.CustomerName.Contains(search) ||
                    x.Customer.CustomerSurname.Contains(search) ||
                    x.Car.Brand.Contains(search) ||
                    x.Car.Model.Contains(search) ||
                    x.Car.Plate.Contains(search)
                );
            }
            ViewData["IsAdmin"] = isAdmin;
            ViewData["CurrentSearch"] = search;
            return View(result.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["CarId"] = new SelectList(
                _context.Cars.Select(x => new
                {
                    x.CarId,
                    CarInfo = x.Brand + " " + x.Model
                }),
                    "CarId",
                    "CarInfo"
                );

            ViewData["CustomerId"] = new SelectList(
                _context.Customers.Select(x => new
                {
                    x.CustomerId,
                    CustomerInfo = x.CustomerName + " " + x.CustomerSurname
                }),
                    "CustomerId",
                    "CustomerInfo"
                );

            return View();
        }

        [HttpPost]
        public IActionResult Create(Rental rent)
        {
            _context.Rentals.Add(rent);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var result = _context.Rentals.Find(id);

            ViewData["CarId"] = new SelectList(
                _context.Cars.Select(x => new
                {
                    x.CarId,
                    CarInfo = x.Brand + " " + x.Model
                }),
                "CarId",
                "CarInfo",
                result.CarId
            );

            ViewData["CustomerId"] = new SelectList(
                _context.Customers.Select(x => new
                {
                    x.CustomerId,
                    CustomerInfo = x.CustomerName + " " + x.CustomerSurname
                }),
                "CustomerId",
                "CustomerInfo",
                result.CustomerId
            );

            return View(result);
        }

        [HttpPost]
        public IActionResult Edit(Rental rent)
        {
            _context.Rentals.Update(rent);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var result = _context.Rentals.Find(id);
            return View(result);
        }

        [HttpPost]
        public IActionResult Delete(Rental rent)
        {
            _context.Rentals.Remove(rent);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
