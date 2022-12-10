namespace ECommerce.Areas.Admin.Controllers;

[Area("Admin"), Route("Admin")]
[Authorize]
public class HomeController : Controller
{
    public IActionResult Index() => View();

    [Route("Search")] public IActionResult Search() => RedirectToAction("Index");
}
