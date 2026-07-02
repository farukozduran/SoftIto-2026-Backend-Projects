using Microsoft.AspNetCore.Mvc;
using Project.Shop.Models;

namespace Project.Shop.Controllers
{
    public class CategoriesController : Controller
    {
        public readonly ApplicationDbContext context;

        public CategoriesController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index(string search, bool isAdmin = false)
        {
            var result = context.Categories.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                result = result.Where(x =>
                x.CategoryName.Contains(search)
                );
            }

            ViewData["IsAdmin"] = isAdmin;
            ViewData["CurrentSearch"] = search;
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var result = context.Categories.Find(id);
            return View(result);
        }

        [HttpPost]
        public IActionResult Edit(int id, Category category)
        {
            context.Categories.Update(category);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var result = context.Categories.Find(id);
            return View(result);
        }

        [HttpPost]
        public IActionResult Delete(int id, Category category)
        {
            context.Categories.Remove(category);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
