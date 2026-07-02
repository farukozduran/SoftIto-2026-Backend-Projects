using Microsoft.AspNetCore.Mvc;
using Rent.App.Models;
using System.Diagnostics;

namespace Rent.App.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
