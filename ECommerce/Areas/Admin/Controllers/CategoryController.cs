namespace ECommerce.Areas.Admin.Controllers;

[Area("Admin"), Route("Admin/Category")]
[Authorize]
public class CategoryController : Controller
{
    private AppDbContext _dbContext;


    public CategoryController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        var categories = await _dbContext.Categories.Select(c => new CategoryViewModel(c.Id, c.ImageUrl) { Name = c.Name }).ToListAsync();

        return View(categories);
    }

    [Route("Create")] 
    public IActionResult Create() => View();

    [Route("Delete")]
    public async Task<IActionResult> Delete(int id)
    {
        var category = await _dbContext.Categories.FirstAsync(category => category.Id == id);

        _dbContext.Categories.Remove(category);
        await _dbContext.SaveChangesAsync();

        return RedirectToAction("Index");
    }

    [Route("Create"), HttpPost]
    public async Task<IActionResult> Create(CreateCategoryViewModel viewModel)
    {
        var category = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Name == viewModel.Name);

        if (category is not null) return Content("Category already exists!");

        category = TypeConverter.Convert<Category, CreateCategoryViewModel>(viewModel);

        var path = $"{Guid.NewGuid()}{Path.GetExtension(viewModel.Image.FileName)}";
        using var fs = new FileStream($"wwwroot/images/icons/{path}", FileMode.CreateNew, FileAccess.Write);
        await viewModel.Image.CopyToAsync(fs);

        category.ImageUrl = path;

        await _dbContext.Categories.AddAsync(category);
        await _dbContext.SaveChangesAsync();

        return RedirectToAction("Index");
    }

    [Route("Search")]
    public async Task<IActionResult> Search(string pattern)
    {
        if (pattern is null) return RedirectToAction("Index");

        var categories = await _dbContext.Categories.Where(c => c.Name.Contains(pattern)).Select(c => new CategoryViewModel(c.Id, c.ImageUrl) { Name = c.Name }).ToListAsync();

        return View(categories);
    }
}
