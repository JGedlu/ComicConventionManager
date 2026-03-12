using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ComicConventionManager.Data;
using ComicConventionManager.Models;

public class NoticeController : Controller
{
    private readonly ApplicationDbContext _context;
    public NoticeController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var notices = _context.Notices
            .Where(n => n.IsPublished)
            .OrderByDescending(n => n.CreatedAt)
            .ToList();

        return View(notices);
    }

    [Authorize(Roles = "Admin")]
    public IActionResult Manage()
    {
        var notices = _context.Notices
            .OrderByDescending(n => n.CreatedAt)
            .ToList();

        return View(notices);
    }

    [Authorize(Roles = "Admin")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult Create(Notice notice)
    {
        if (ModelState.IsValid)
        {
            _context.Notices.Add(notice);
            _context.SaveChanges();
            return RedirectToAction("Manage");
        }

        return View(notice);
    }

    [Authorize(Roles = "Admin")]
    public IActionResult Edit(int id)
    {
        var notice = _context.Notices.Find(id);
        return View(notice);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult Edit(Notice notice)
    {
        _context.Notices.Update(notice);
        _context.SaveChanges();
        return RedirectToAction("Manage");
    }

    [Authorize(Roles = "Admin")]
    public IActionResult Delete(int id)
    {
        var notice = _context.Notices.Find(id);

        _context.Notices.Remove(notice);
        _context.SaveChanges();

        return RedirectToAction("Manage");
    }

    [Authorize(Roles = "Admin")]
    public IActionResult Publish(int id)
    {
        var notice = _context.Notices.Find(id);

        if (notice != null)
        {
            notice.IsPublished = true;
            _context.SaveChanges();
        }

        return RedirectToAction("Manage");
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult Update([FromBody] Notice updatedNotice)
    {
        var notice = _context.Notices.Find(updatedNotice.NoticeId);

        if (notice != null)
        {
            notice.Title = updatedNotice.Title;
            notice.Content = updatedNotice.Content;

            _context.SaveChanges();
        }

        return Ok();
    }

    [Authorize(Roles = "Admin")]
    public IActionResult Unpublish(int id)
    {
        var notice = _context.Notices.Find(id);

        if (notice != null)
        {
            notice.IsPublished = false;
            _context.SaveChanges();
        }

        return RedirectToAction("Manage");
    }
}