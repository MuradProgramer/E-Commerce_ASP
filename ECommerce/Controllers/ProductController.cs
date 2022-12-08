namespace ECommerce.Controllers;

[Route("Product")]
public class ProductController : Controller
{
    private readonly AppDbContext _dbContext;


    public ProductController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        var products = await _dbContext.Products.Include("Category")
            .Select(p => new ProductViewModel(p.Id, p.Category.Name, null) { Name = p.Name, Description = p.Description, Price = p.Price, ImageUrl = p.ImageUrl })
            .ToListAsync();

        return View(products);
    }
}
