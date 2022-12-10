namespace ECommerce.Areas.Admin.Controllers;

[Area("Admin"), Route("Admin/Tag")]
[Authorize]
public class TagController : Controller
{
    private AppDbContext _dbContext;


    public TagController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        var tags = await _dbContext.Tags.Select(t => new TagViewModel(t.Id) { Title = t.Title }).ToListAsync();

        return View(tags);
    }

    [Route("Create")]
    public IActionResult Create() => View();

    [Route("Delete")]
    public async Task<IActionResult> Delete(int id)
    {
        var tag = await _dbContext.Tags.FirstAsync(tag => tag.Id == id);

        _dbContext.Tags.Remove(tag);
        await _dbContext.SaveChangesAsync();

        return RedirectToAction("Index");
    }

    [Route("Create"), HttpPost]
    public async Task<IActionResult> Create(TagViewModel viewModel)
    {
        var tag = await _dbContext.Tags.FirstOrDefaultAsync(t => t.Title == viewModel.Title);

        if (tag is not null) return Content("Tag already exists!");

        tag = TypeConverter.Convert<Tag, TagViewModel>(viewModel);

        await _dbContext.Tags.AddAsync(tag);
        await _dbContext.SaveChangesAsync();

        return RedirectToAction("Index");
    }

    [Route("Search")]
    public async Task<IActionResult> Search(string pattern)
    {
        var tags = await _dbContext.Tags.Where(t => t.Title.Contains(pattern)).Select(t => new TagViewModel(t.Id) { Title = t.Title }).ToListAsync();

        return View(tags);
    }
}
