using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Shop.Models;

namespace Project.Shop.Controllers
{
    public class OrdersController : Controller
    {
        public readonly ApplicationDbContext context;

        public OrdersController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var result = context.Orders
                .Include(x => x.Customer)
                .Include(x => x.Product)
                .ToList();

            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(context.Customers, "CustomerId", "CustomerName");
            ViewData["ProductId"] = new SelectList(context.Products, "ProductId", "ProductName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Order order)
        {
            context.Orders.Add(order);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var result = context.Orders.Find(id);
            ViewData["CustomerId"] = new SelectList(context.Customers, "CustomerId", "CustomerName");
            ViewData["ProductId"] = new SelectList(context.Products, "ProductId", "ProductName");
            return View(result);
        }

        [HttpPost]
        public IActionResult Edit(Order order)
        {
            context.Orders.Update(order);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var result = context.Orders.Find(id);
            return View(result);
        }

        [HttpPost]
        public IActionResult Delete(Order order)
        {
            context.Orders.Remove(order);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
