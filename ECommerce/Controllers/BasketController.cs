namespace ECommerce.Controllers;

[Route("Basket")]
public class BasketController : Controller
{
    private readonly AppDbContext _dbContext;


    public BasketController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    [Route("Index")]
    public IActionResult Index()
    {
        var cookie = Request.Cookies["basket"];

        var viewProducts = cookie is null ? new List<BasketProductViewModel>() : JsonSerializer.Deserialize<List<BasketProductViewModel>>(cookie);

        return View(viewProducts);
    }

    [Route("AddProduct")]
    public IActionResult AddProduct(int id, string? returnUrl)
    {
        var cookie = Request.Cookies["basket"];

        var viewProducts = cookie is null ? new List<BasketProductViewModel>() : JsonSerializer.Deserialize<List<BasketProductViewModel>>(cookie);

        if (viewProducts.Exists(viewModel => viewModel.Id == id)) viewProducts.First(viewModel => viewModel.Id == id).Count++;
        else
        {
            var product = _dbContext.Products.First(product => product.Id == id);

            var viewProduct = new BasketProductViewModel(product.Id, product.ImageUrl, 1) { Name = product.Name, Description = product.Description, Price = product.Price };

            viewProducts.Add(viewProduct);
        }

        Response.Cookies.Append("basket", JsonSerializer.Serialize(viewProducts));

        return string.IsNullOrEmpty(returnUrl) ? RedirectToAction("Index", "Product") : Redirect(returnUrl);
    }

    [Route("Order"), Authorize(Roles = "Client")]
    public async Task<IActionResult> Order()
    {
        var viewProducts = JsonSerializer.Deserialize<List<BasketProductViewModel>>(Request.Cookies["basket"]);

        if (viewProducts.Count == 0) return RedirectToAction("Index", "Product");

        var order = new Order()
        {
            Time = DateTime.Now,
            CustomerName = User.Identity.Name,
        };

        await _dbContext.AddAsync(order);
        await _dbContext.SaveChangesAsync();

        foreach (var viewProduct in viewProducts)
        {
            var productOrder = new ProductOrder(viewProduct.Id, order.Id, viewProduct.Count);

            _dbContext.Add(productOrder);
        }

        await _dbContext.SaveChangesAsync();

        Response.Cookies.Delete("basket");

        return Content("Success");
    }

    [Route("IncreaseProduct")]
    public IActionResult IncreaseProduct(int id)
    {
        var cookie = Request.Cookies["basket"];

        if (cookie is not null)
        {
            var viewProducts = JsonSerializer.Deserialize<List<BasketProductViewModel>>(cookie);

            var viewProduct = viewProducts.FirstOrDefault(viewModel => viewModel.Id == id);

            if (viewProduct is not null)
            {
                viewProduct.Count++;

                cookie = JsonSerializer.Serialize(viewProducts);

                Response.Cookies.Append("basket", cookie);
            }
        }

        return RedirectToAction("Index");
    }

    [Route("DecreaseProduct")]
    public IActionResult DecreaseProduct(int id)
    {
        var cookie = Request.Cookies["basket"];

        if (cookie is not null)
        {
            var viewProducts = JsonSerializer.Deserialize<List<BasketProductViewModel>>(cookie);

            var viewProduct = viewProducts.FirstOrDefault(viewModel => viewModel.Id == id);

            if (viewProduct is not null)
            {
                if (viewProduct.Count > 0) viewProduct.Count--;

                cookie = JsonSerializer.Serialize(viewProducts);

                Response.Cookies.Append("basket", cookie);
            }
        }

        return RedirectToAction("Index");
    }

    [Route("Clear")]
    public IActionResult Clear()
    {
        Response.Cookies.Delete("basket");

        return RedirectToAction("Index");
    }

    [Route("Remove")]
    public IActionResult Remove(int id)
    {
        var cookie = Request.Cookies["basket"];

        if (cookie is not null)
        {
            var viewProducts = JsonSerializer.Deserialize<List<BasketProductViewModel>>(cookie);

            viewProducts.RemoveAll(viewModel => viewModel.Id == id);

            cookie = JsonSerializer.Serialize(viewProducts);

            Response.Cookies.Append("basket", cookie);
        }

        return RedirectToAction("Index");
    }
}
