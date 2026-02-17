using Microsoft.AspNetCore.Mvc;

namespace ComicConventionManager.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
