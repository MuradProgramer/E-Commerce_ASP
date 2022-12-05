namespace ECommerce.Areas.Admin.Controllers;

[Area("Admin"), Route("Category")]
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
        var categories = await _dbContext.Categories.Select(c => new CategoryViewModel(c.Id) { Name = c.Name }).ToListAsync();

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
    public async Task<IActionResult> Create(CategoryViewModel viewModel)
    {
        var category = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Name == viewModel.Name);

        if (category is not null) return Content("Category already exists!");

        category = TypeConverter.Convert<Category, CategoryViewModel>(viewModel);

        await _dbContext.Categories.AddAsync(category);
        await _dbContext.SaveChangesAsync();

        return RedirectToAction("Index");
    }

    [Route("Search")]
    public async Task<IActionResult> Search(string pattern)
    {
        var categories = await _dbContext.Categories.Where(c => c.Name.Contains(pattern)).Select(c => new CategoryViewModel(c.Id) { Name = c.Name }).ToListAsync();

        return View(categories);
    }
}
