using Microsoft.AspNetCore.Mvc;
using Project.World.Cup.Data;

namespace Project.World.Cup.UI.Controllers
{
    public class MatchEventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MatchEventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
