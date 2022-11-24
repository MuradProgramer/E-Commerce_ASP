namespace ECommerce.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Category")]
public class CategoryController : Controller
{
    private AppDbContext _dbContext;


    public CategoryController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public IActionResult Index()
    {
        var categories = _dbContext.Categories.Select(c => new CategoryViewModel(c.Id) { Name = c.Name }).ToList();

        return View(categories);
    }

    [Route("Create")]
    public IActionResult Create() => View();

    [Route("Delete")]
    public IActionResult Delete(int id)
    {
        var category = _dbContext.Categories.First(category => category.Id == id);

        _dbContext.Categories.Remove(category);
        _dbContext.SaveChanges();

        return RedirectToAction("Index");
    }


    [Route("Create")]
    [HttpPost]
    public IActionResult Create(CategoryViewModel viewModel)
    {
        var category = _dbContext.Categories.FirstOrDefault(c => c.Name == viewModel.Name);

        if (category is not null) return Content("Category already exists!");

        category = TypeConverter.Convert<Category, CategoryViewModel>(viewModel);

        _dbContext.Categories.Add(category);
        _dbContext.SaveChanges();

        return RedirectToAction("Index");
    }
}
