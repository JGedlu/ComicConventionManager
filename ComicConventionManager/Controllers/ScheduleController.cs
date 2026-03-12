using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ComicConventionManager.Data;
using ComicConventionManager.Models;

namespace ComicConventionManager.Controllers
{
    [Authorize]
    public class ScheduleController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ScheduleController(ApplicationDbContext context,
                                  UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var panels = _context.UserPanels
                .Where(up => up.UserId == user.Id)
                .Select(up => up.Panel)
                .ToList();

            return View(panels);
        }

        public async Task<IActionResult> Add(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (!_context.UserPanels.Any(x => x.UserId == user.Id && x.PanelId == id))
            {
                _context.UserPanels.Add(new UserPanel
                {
                    UserId = user.Id,
                    PanelId = id
                });
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Remove(int id, string returnUrl = null)
        {
            var user = await _userManager.GetUserAsync(User);
            var entry = _context.UserPanels
                .FirstOrDefault(x => x.UserId == user.Id && x.PanelId == id);

            if (entry != null)
            {
                _context.UserPanels.Remove(entry);
                await _context.SaveChangesAsync();
            }

            if (!string.IsNullOrEmpty(returnUrl))
                return Redirect(returnUrl);

            return RedirectToAction("Index", "Home");
        }
    }
}