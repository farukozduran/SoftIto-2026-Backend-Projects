using Microsoft.AspNetCore.Mvc;
using Rent.App.Models;

namespace Rent.App.Controllers
{
    public class CustomersController : Controller
    {
        public readonly AppDbContext _context;

        public CustomersController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string search, bool isAdmin = false)
        {
            var result = _context.Customers.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                result = result.Where(x =>
                    x.CustomerName.Contains(search) ||
                    x.CustomerSurname.Contains(search) ||
                    (x.Phone != null && x.Phone.Contains(search)) ||
                    (x.Email != null && x.Email.Contains(search))
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
        public IActionResult Create(Customer customer)
        {
            _context.Add(customer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var result = _context.Customers.Find(id);
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            _context.Update(customer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var result = _context.Customers.Find(id);
            return View(result);
        }
        [HttpPost]
        public IActionResult Delete(int id, Customer customer)
        {
            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
