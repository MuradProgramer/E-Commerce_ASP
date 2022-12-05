namespace ECommerce.Areas.Admin.Controllers;

[Area("Admin"), Route("Admin")]
public class HomeController : Controller
{
    public IActionResult Index() => View();
}
