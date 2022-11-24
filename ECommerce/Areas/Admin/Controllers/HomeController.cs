namespace ECommerce.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin")]
public class HomeController : Controller
{
	public HomeController(AppDbContext dbContext)
	{
        if (dbContext.Products.Count() <= 10)
		{
			var category = dbContext.Categories.FirstOrDefault(c => c.Name == "Car");

			if (category is null)
			{
				dbContext.Categories.Add(new Category() { Name = "Car" });
				dbContext.SaveChanges();
			}

			category = dbContext.Categories.First(c => c.Name == "Car");

            var products = new Faker<Product>()
				.RuleFor(p => p.Title, f => string.Format("{0} {1}", f.Vehicle.Manufacturer(), f.Vehicle.Model()))
				.RuleFor(p => p.Description, f => string.Format("{0}", f.Vehicle.Fuel()))
				.RuleFor(p => p.Price, f => f.Vehicle.Random.UShort(10000))
				.Generate(10);

			products.ForEach(p => p.CategoryId = category.Id);

			dbContext.Products.AddRange(products);

            dbContext.SaveChanges();
        }
	}


    public IActionResult Index() => View();
}
