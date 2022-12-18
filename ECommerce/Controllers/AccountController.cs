namespace ECommerce.Areas.Admin.Controllers;

[Route("Account")]
public class AccountController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;


    public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }


    [Route("Register")]
    public IActionResult Register() => View();

    [HttpPost, Route("Register")]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = new AppUser
            {
                UserName = string.Format("{0} {1}", model.Name, model.Surname),
                FirstName = model.Name,
                LastName = model.Surname,
                Email = model.Email
            };


            var userCheck = await _userManager.FindByEmailAsync(model.Email);
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded && userCheck == null)
            {
                await _signInManager.SignInAsync(user, true);
                return RedirectToAction("Index", "Home", new { area="Admin" });
            }
            else
            {
                if (userCheck != null)
                    ModelState.AddModelError("register", "this email is alredy exist");
                else
                {
                    foreach (var item in result.Errors)
                        ModelState.AddModelError(item.Code, item.Description);
                }
            }
        }

        return View();
    }

    [Route("Login")]
    public IActionResult Login(string? returnUrl)
    {
        ViewBag.ReturnUrl = returnUrl;
        return View();
    }

    [HttpPost, Route("Login")]
    public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user != null)
            {
                if (await _userManager.CheckPasswordAsync(user, model.Password))
                {
                    await _signInManager.SignInAsync(user, true);

                    if (!string.IsNullOrWhiteSpace(returnUrl)) return Redirect(returnUrl);
                    return RedirectToAction("Index", "Home");
                }
            }
        }

        ModelState.AddModelError("login", "Incorrect username or password");

        return View();
    }

    [Route("Logout")]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}
