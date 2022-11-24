namespace ECommerce.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Product")]
public class ProductController : Controller
{
    private AppDbContext _dbContext;


    public ProductController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    
    public IActionResult Index()
    {
        var products = _dbContext.Products.Include("Category")
            .Select(p => new ProductViewModel(p.Category.Name, p.Id) { Title = p.Title, Description = p.Description, Price = p.Price })
            .ToList();

        return View(products);
    }

    [Route("Create")]
    public IActionResult Create()
    {
        var categories = _dbContext.Categories.Select(c => new SelectListItem(c.Name, c.Id.ToString())).ToList();

        ViewData["Categories"] = categories;

        return View();
    }

    [Route("Delete")]
    public IActionResult Delete(int id)
    {
        var product = _dbContext.Products.First(product => product.Id == id);

        _dbContext.Products.Remove(product);
        _dbContext.SaveChanges();

        return RedirectToAction("Index");
    }

    [Route("Create")]
    [HttpPost]
    public IActionResult Create(CreateProductViewModel viewModel)
    {
        var product = TypeConverter.Convert<Product, CreateProductViewModel>(viewModel);

        _dbContext.Products.Add(product);
        _dbContext.SaveChanges();

        return RedirectToAction("Index");
    }
}
