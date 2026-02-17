using Microsoft.AspNetCore.Mvc;

namespace ComicConventionManager.Controllers
{
    public class GuestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
