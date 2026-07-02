using Microsoft.AspNetCore.Mvc;

namespace Project.Shop.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
