namespace ECommerce.ViewComponents;

public class AuthViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        ViewBag.ReturnUrl = $"{Request.Path}{Request.QueryString}";

        return View();
    }
}
