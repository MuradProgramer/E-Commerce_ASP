namespace ECommerce.ViewComponents;

public class BasketViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        var cookie = Request.Cookies["basket"];

        var viewProducts = cookie is null ? new List<BasketProductViewModel>() : JsonSerializer.Deserialize<List<BasketProductViewModel>>(cookie);

        ViewBag.Count = viewProducts.Count;

        return View();
    }
}
