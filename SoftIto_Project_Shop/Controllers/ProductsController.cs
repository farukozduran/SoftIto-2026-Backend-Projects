using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Shop.Models;

namespace Project.Shop.Controllers
{
    public class ProductsController : Controller
    {
        public readonly ApplicationDbContext context;

        public ProductsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index(string search, int? categoryId, bool isAdmin = false)
        {
            var result = context.Products.Include(p => p.Category).AsQueryable();

            if(categoryId != null)
            {
                result = result.Where(x => x.CategoryId == categoryId);

                var category = context.Categories.Find(categoryId);
                ViewData["CategoryName"] = category?.CategoryName;
            }

            if (!string.IsNullOrEmpty(search))
            {
                result = result.Where(x => x.ProductName.Contains(search));
            }

            ViewData["IsAdmin"] = isAdmin;
            ViewData["CurrentSearch"] = search;
            ViewData["CurrentCategoryId"] = categoryId;
            return View(result.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(context.Categories, "CategoryId", "CategoryName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var result = context.Products.Find(id);
            ViewData["CategoryId"] = new SelectList(context.Categories, "CategoryId", "CategoryName");
            return View(result);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            context.Products.Update(product);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var result = context.Products.Find(id);
            return View(result);
        }

        [HttpPost]
        public IActionResult Delete(Product product)
        {
            context.Products.Remove(product);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
