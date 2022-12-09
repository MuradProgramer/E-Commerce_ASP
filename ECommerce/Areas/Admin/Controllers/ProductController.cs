namespace ECommerce.Areas.Admin.Controllers;

[Area("Admin"), Route("Admin/Product")]
public class ProductController : Controller
{
    private AppDbContext _dbContext;


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

        return View(products);
    }

    [Route("Create")]
    public async Task<IActionResult> Create()
    {
        var categories = await _dbContext.Categories.Select(c => new SelectListItem(c.Name, c.Id.ToString())).ToListAsync();
        var tags = await _dbContext.Tags.Select(t => new SelectListItem(t.Title, t.Id.ToString())).ToListAsync();
        
        ViewData["Categories"] = categories;
        ViewData["Tags"] = tags;

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

        var path = $"{Guid.NewGuid()}{Path.GetExtension(viewModel.Image.FileName)}";
        using var fs = new FileStream($"wwwroot/images/products/{path}", FileMode.CreateNew, FileAccess.Write);
        await viewModel.Image.CopyToAsync(fs);

        product.ImageUrl = path;

        await _dbContext.Products.AddAsync(product);
        await _dbContext.SaveChangesAsync();

        if (viewModel.tagIds is not null) 
            foreach (var tag in viewModel.tagIds) _dbContext.ProductTags.AddAsync(new ProductTag(product.Id, tag));
        
        await _dbContext.SaveChangesAsync();

        return RedirectToAction("Index");
    }

    [Route("Search")]
    public async Task<IActionResult> Search(string pattern)
    {
        var products = await _dbContext.Products.Include("Category").Where(p => p.Name.Contains(pattern))
            .Select(p => new ProductViewModel(p.Id, p.Category.Name, null) { Name = p.Name, Description = p.Description, Price = p.Price, ImageUrl = p.ImageUrl })
            .ToListAsync();

        return View(products);
    }
}
