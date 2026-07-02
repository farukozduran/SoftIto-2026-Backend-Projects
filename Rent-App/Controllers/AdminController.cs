using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rent.App.Models;

namespace Rent.App.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;

        public AdminController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.LastThreeRentals = _context.Rentals
                .Include(x => x.Customer)
                .Include(x => x.Car)
                .OrderByDescending(x => x.RentDate)
                .Take(3)
                .ToList();

            ViewBag.FirstThreeCustomers = _context.Customers
                .OrderBy(x => x.CustomerId)
                .Take(3)
                .ToList();

            ViewBag.LastThreeCustomers = _context.Customers
                .OrderByDescending(x => x.CustomerId)
                .Take(3)
                .ToList();

            ViewBag.CarsContainsA = _context.Cars
                .Where(x =>
                    x.Brand.ToLower().Contains("a") ||
                    x.Model.ToLower().Contains("a") ||
                    x.Plate.ToLower().Contains("a"))
                .ToList();

            ViewBag.CustomersContainsA = _context.Customers
                .Where(x =>
                    x.CustomerName.ToLower().Contains("a") ||
                    x.CustomerSurname.ToLower().Contains("a"))
                .ToList();

            return View();
        }
    }
}
