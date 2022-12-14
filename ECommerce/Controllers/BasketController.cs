namespace ECommerce.Controllers;

[Route("Basket")]
public class BasketController: Controller
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
    public IActionResult AddProduct(int id)
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

        return RedirectToAction("Index", "Product");
    }

    [Route("Order")]
    public IActionResult Order()
    {
        var cookie = Request.Cookies["basket"];

        var viewProducts = cookie is null ? new List<BasketProductViewModel>() : JsonSerializer.Deserialize<List<BasketProductViewModel>>(cookie);

        if (viewProducts.Count == 0) return Content("Get product aldala!");

        return View();
    }

    [HttpPost, Route("Order")]
    public IActionResult Order(OrderViewModel viewModel)
    {
        var viewProducts = JsonSerializer.Deserialize<List<BasketProductViewModel>>(Request.Cookies["basket"]);

        viewModel.Time = DateTime.Now;
        viewModel.Products = viewProducts;

        return Content("Success");
    }
}
