namespace ECommerce.Areas.Admin.Controllers;

[Area("Admin"), Route("Product")]
public class ProductController : Controller
{
    private AppDbContext _dbContext;


    public ProductController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    
    public async Task<IActionResult> Index()
    {
        var products = await _dbContext.Products.Include("Category")
            .Select(p => new ProductViewModel(p.Category.Name, p.Id) { Title = p.Title, Description = p.Description, Price = p.Price })
            .ToListAsync();

        return View(products);
    }

    [Route("Create")]
    public async Task<IActionResult> Create()
    {
        var categories = await _dbContext.Categories.Select(c => new SelectListItem(c.Name, c.Id.ToString())).ToListAsync();

        ViewData["Categories"] = categories;

        return View();
    }

    [Route("Delete")]
    public async Task<IActionResult> Delete(int id)
    {
        var product = await _dbContext.Products.FirstAsync(product => product.Id == id);

        _dbContext.Products.Remove(product);
        await _dbContext.SaveChangesAsync();

        return RedirectToAction("Index");
    }

    [Route("Create"), HttpPost]
    public async Task<IActionResult> Create(CreateProductViewModel viewModel)
    {
        var product = TypeConverter.Convert<Product, CreateProductViewModel>(viewModel);

        await _dbContext.Products.AddAsync(product);
        await _dbContext.SaveChangesAsync();

        return RedirectToAction("Index");
    }
}
