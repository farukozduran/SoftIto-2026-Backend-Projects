using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Shop.Models;

namespace Project.Shop.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.LastThreeOrders = _context.Orders
                .Include(x => x.Customer)
                .Include(x => x.Product)
                .OrderByDescending(x => x.OrderId)
                .Take(3)
                .ToList();

            ViewBag.FirstThreeCategories = _context.Categories
                .OrderBy(x => x.CategoryId)
                .Take(3)
                .ToList();

            ViewBag.LastThreeProducts = _context.Products
                .Include(x => x.Category)
                .OrderByDescending(x => x.ProductId)
                .Take(3)
                .ToList();

            ViewBag.ProductsContainsA = _context.Products
                .Where(x => x.ProductName.Contains("a"))
                .ToList();

            ViewBag.CustomersContainsA = _context.Customers
                .Where(x => x.CustomerName.Contains("a"))
                .ToList();

            return View();
        }
    }
}
