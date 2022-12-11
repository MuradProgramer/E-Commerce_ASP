﻿
using ECommerce.Models;

namespace ECommerce.Areas.Admin.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<AppUser> userManager;
    private readonly SignInManager<AppUser> signInManager;

    public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
    {
        this.userManager = userManager;
        this.signInManager = signInManager;
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = new AppUser
            {
                UserName = string.Format("{0}{1}", model.Name, model.Surname),
                Email = model.Email
            };
            var userCheck = await userManager.FindByEmailAsync(model.Email);
            var result = await userManager.CreateAsync(user, model.Password);
            if (result.Succeeded && userCheck == null)
            {
                await signInManager.SignInAsync(user, true);
                return RedirectToAction("Index", "Home", new { area="Admin" });
            }
            else
            {
                if (userCheck != null)
                    ModelState.AddModelError("register", "this email is alredy exist");
                //foreach (var item in result.Errors)
                //    ModelState.AddModelError(item.Code, item.Description);
            }
        }
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Logout()
    {
        await signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

    public IActionResult Login(string? returnUrl)
    {
        ViewBag.ReturnUrl = returnUrl;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl)
    {
        if (ModelState.IsValid)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                if (await userManager.CheckPasswordAsync(user, model.Password))
                {
                    await signInManager.SignInAsync(user, true);
                    if (!string.IsNullOrWhiteSpace(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
            }
        }
        ModelState.AddModelError("login", "Incorrect username or password");
        return View();
    }
}
