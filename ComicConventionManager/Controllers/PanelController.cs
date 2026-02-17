using Microsoft.AspNetCore.Mvc;

namespace ComicConventionManager.Controllers
{
    public class PanelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
