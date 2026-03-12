using ComicConventionManager.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ComicConventionManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(ApplicationDbContext context,
                              UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var panels = _context.Panels
                .OrderBy(p => p.StartDate)
                .ToList();

            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.GetUserAsync(User);

                ViewBag.UserPanels = _context.UserPanels
                    .Where(x => x.UserId == user.Id)
                    .Select(x => x.PanelId)
                    .ToList();
            }

            return View(panels);
        }
    }
}