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
            var totalOrders = _context.Orders.Count();
            var totalRevenue = _context.Orders.Include(o => o.Product).Sum(o => (decimal?)o.Product.Price) ?? 0;
            var totalCustomers = _context.Customers.Count();
            var totalProducts = _context.Products.Count();

            ViewBag.DashboardSummary = new DashboardSummaryReport
            {
                TotalOrders = totalOrders,
                TotalRevenue = totalRevenue,
                TotalCustomers = totalCustomers,
                TotalProducts = totalProducts
            };

            ViewBag.TopSellingProducts = _context.Orders
                .Include(o => o.Product)
                .ThenInclude(p => p.Category)
                .AsEnumerable()
                .GroupBy(o => new { o.Product.ProductName, o.Product.Category.CategoryName })
                .Select(g => new TopSellingProductReport
                {
                    ProductName = g.Key.ProductName,
                    CategoryName = g.Key.CategoryName,
                    SalesCount = g.Count(),
                    TotalRevenue = g.Sum(o => o.Product.Price)
                })
                .OrderByDescending(r => r.SalesCount)
                .Take(5)
                .ToList();

            ViewBag.TopCustomers = _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.Product)
                .AsEnumerable()
                .GroupBy(o => new { o.Customer.CustomerName, o.Customer.ImageUrl })
                .Select(g => new TopCustomerReport
                {
                    CustomerName = g.Key.CustomerName,
                    ImageUrl = g.Key.ImageUrl,
                    OrderCount = g.Count(),
                    TotalSpent = g.Sum(o => o.Product.Price)
                })
                .OrderByDescending(r => r.TotalSpent)
                .Take(5)
                .ToList();

            ViewBag.CategorySales = _context.Orders
                .Include(o => o.Product)
                .ThenInclude(p => p.Category)
                .AsEnumerable()
                .GroupBy(o => o.Product.Category.CategoryName)
                .Select(g => new CategorySalesReport
                {
                    CategoryName = g.Key,
                    SalesCount = g.Count(),
                    TotalRevenue = g.Sum(o => o.Product.Price)
                })
                .OrderByDescending(r => r.TotalRevenue)
                .ToList();

            ViewBag.LatestOrders = _context.Orders
                .Include(x => x.Customer)
                .Include(x => x.Product)
                .OrderByDescending(x => x.OrderId)
                .Take(5)
                .ToList();

            return View();
        }
    }
}
