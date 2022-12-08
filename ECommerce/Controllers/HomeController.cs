namespace ECommerce.Controllers;

[Route("")]
public class HomeController : Controller
{
    public IActionResult Index() => View();
}
