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
            ViewBag.LatestRentals = (from r in _context.Rentals
                                     join c in _context.Customers on r.CustomerId equals c.CustomerId
                                     join car in _context.Cars on r.CarId equals car.CarId
                                     orderby r.RentDate descending
                                     select new RentalDetailReport
                                     {
                                         CustomerName = c.CustomerName,
                                         CustomerSurname = c.CustomerSurname,
                                         CarBrand = car.Brand,
                                         CarModel = car.Model,
                                         RentDate = r.RentDate,
                                         TotalPrice = r.TotalPrice
                                     }).Take(5).ToList();

            ViewBag.CustomerSpendings = (from r in _context.Rentals
                                         join c in _context.Customers on r.CustomerId equals c.CustomerId
                                         group r by new { c.CustomerId, c.CustomerName, c.CustomerSurname } into g
                                         orderby g.Sum(x => x.TotalPrice ?? 0) descending
                                         select new CustomerSpendingReport
                                         {
                                             CustomerName = g.Key.CustomerName,
                                             CustomerSurname = g.Key.CustomerSurname,
                                             RentalCount = g.Count(),
                                             TotalSpent = g.Sum(x => x.TotalPrice ?? 0)
                                         }).Take(5).ToList();

            ViewBag.CarRentalCounts = (from r in _context.Rentals
                                       join car in _context.Cars on r.CarId equals car.CarId
                                       group r by new { car.CarId, car.Brand, car.Model, car.Plate } into g
                                       orderby g.Count() descending
                                       select new CarRentalCountReport
                                       {
                                           CarBrand = g.Key.Brand,
                                           CarModel = g.Key.Model,
                                           Plate = g.Key.Plate,
                                           RentalCount = g.Count()
                                       }).Take(5).ToList();

            return View();
        }
    }
}
