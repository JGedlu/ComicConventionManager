using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using ComicConventionManager.Models;

public class AccountController : Controller
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;

    public AccountController(
        UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> MakeAdmin()
    {
        var user = await _userManager.FindByEmailAsync("admin@admin.com");

        if (user != null)
        {
            await _userManager.AddToRoleAsync(user, "Admin");
        }

        return Content("User promoted to Admin");
    }

    [HttpPost]
    public async Task<IActionResult> Login(string Email, string Password)
    {
        if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
        {
            ModelState.AddModelError("", "Please enter both username/email and password.");
            return View();
        }

        var user = await _userManager.FindByEmailAsync(Email);

        if (user == null)
        {
            user = await _userManager.FindByNameAsync(Email);
        }

        if (user == null)
        {
            ModelState.AddModelError("", "Account not found.");
            return View();
        }

        var result = await _signInManager.PasswordSignInAsync(
            user.UserName,
            Password,
            false,
            false);

        if (result.Succeeded)
        {
            return RedirectToAction("Index", "Home");
        }

        ModelState.AddModelError("", "Incorrect password.");
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(string Name, string Email, string Password, string ConfirmPassword)
    {
        if (Password != ConfirmPassword)
        {
            ModelState.AddModelError("", "Passwords do not match.");
            return View("Login");
        }

        if (string.IsNullOrWhiteSpace(Name))
        {
            ModelState.AddModelError("", "Username is required.");
            return View("Login");
        }

        var existing = await _userManager.FindByNameAsync(Name);
        if (existing != null)
        {
            ModelState.AddModelError("", "Username already exists.");
            return View("Login");
        }

        var user = new IdentityUser
        {
            UserName = Name,
            Email = Email
        };

        var result = await _userManager.CreateAsync(user, Password);

        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, "User");

            await _signInManager.SignInAsync(user, false);

            return RedirectToAction("Index", "Home");
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError("", error.Description);
        }

        return View("Login");
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}