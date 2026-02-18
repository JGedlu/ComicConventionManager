using Microsoft.AspNetCore.Mvc;
using ComicConventionManager.Data;
using System.Linq;

namespace ComicConventionManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var panels = _context.Panels
                .OrderBy(p => p.StartDate)
                .ToList();

            return View(panels);
        }
    }
}