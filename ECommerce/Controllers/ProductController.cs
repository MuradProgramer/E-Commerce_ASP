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
            .Select(p => new ProductViewModel(p.Id, p.Category.Name, p.ImageUrl) { Name = p.Name, Description = p.Description, Price = p.Price })
            .ToListAsync();

        var categories = await _dbContext.Categories.Select(c => new CategoryViewModel(c.Id, c.ImageUrl) { Name = c.Name }).ToListAsync();
        var tags = await _dbContext.Tags.Select(t => new FilterTagViewModel(t.Id, false) { Title = t.Title }).ToListAsync();

        ViewData["Products"] = products;
        ViewData["Categories"] = categories;

        return View(tags);
    }

    [Route("FilterOnCategory")]
    public async Task<IActionResult> FilterOnCategory(int categoryId)
    {
        var products = await _dbContext.Products.Include("Category").Where(p => p.CategoryId == categoryId)
            .Select(p => new ProductViewModel(p.Id, p.Category.Name, p.ImageUrl) { Name = p.Name, Description = p.Description, Price = p.Price })
            .ToListAsync();

        var categories = await _dbContext.Categories.Select(c => new CategoryViewModel(c.Id, c.ImageUrl) { Name = c.Name }).ToListAsync();
        var tags = await _dbContext.Tags.Select(t => new FilterTagViewModel(t.Id, false) { Title = t.Title }).ToListAsync();

        ViewData["Products"] = products;
        ViewData["Categories"] = categories;

        return View("Index", tags);
    }

    [Route("FilterOnTags")]
    public async Task<IActionResult> FilterOnTags(List<FilterTagViewModel> tags)
    {
        var productIds = new List<int>();

        foreach (var item in tags)
        {
            if (item.Checked)
            {
                var result = await _dbContext.ProductTags.Include(pt => pt.Product)
                                                         .Where(pt => pt.TagId == item.Id)
                                                         .Select(pt => pt.ProductId)
                                                         .ToListAsync();

                productIds.AddRange(result);
            }
        }

        List<ProductViewModel> products = null;

        if (productIds.Count == 0)
        {
            products = await _dbContext.Products.Include("Category")
                                                .Select(p => new ProductViewModel(p.Id, p.Category.Name, p.ImageUrl) { Name = p.Name, Description = p.Description, Price = p.Price })
                                                .ToListAsync();
        }
        else
        {
            productIds.Distinct();

            products = await _dbContext.Products.Include("Category").Where(p => productIds.Contains(p.Id))
                                                .Select(p => new ProductViewModel(p.Id, p.Category.Name, p.ImageUrl) { Name = p.Name, Description = p.Description, Price = p.Price })
                                                .ToListAsync();
        }
        
        var categories = await _dbContext.Categories.Select(c => new CategoryViewModel(c.Id, c.ImageUrl) { Name = c.Name }).ToListAsync();

        ViewData["Products"] = products;
        ViewData["Categories"] = categories;

        return View("Index", tags);
    }
}
