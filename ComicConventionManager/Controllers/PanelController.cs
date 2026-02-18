using ComicConventionManager.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComicConventionManager.Controllers
{
    public class PanelController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PanelController(ApplicationDbContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var panels = await _context.Panels.ToListAsync();
            return View(panels);
        }
    }
}
