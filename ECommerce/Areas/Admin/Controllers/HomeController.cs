namespace ECommerce.Areas.Admin.Controllers;

[Area("Admin"), Route("Admin")]
public class HomeController : Controller
{
    [Route("Index")] public IActionResult Index() => View();

    [Route("Search")] public IActionResult Search() => RedirectToAction("Index");
}
