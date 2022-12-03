namespace ECommerce.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin")]
public class HomeController : Controller
{
	public HomeController(AppDbContext dbContext)
	{
        if (dbContext.Products.Count() <= 10)
		{
			var category = dbContext.Categories.FirstOrDefault(c => c.Name == "Smartphone");

			if (category is null)
			{
				dbContext.Categories.Add(new Category() { Name = "Smartphone" });
				dbContext.SaveChanges();
			}

			category = dbContext.Categories.First(c => c.Name == "Smartphone");

			var products = new List<Product>()
			{
				new Product("iPhone 11", "128 GB Black", 1399.99),
				new Product("Samsung Galaxy A53", "128 GB 5G Blue", 899.99),
				new Product("Xiaomi Redmi Note 11", "4/64 GB Star Blue", 459.99),
				new Product("iPhone 13", "128 GB Midnight", 1999.99),
				new Product("Xiaomi 12 Lite", "6/128 GB Lite Pink", 899.99),
			};

			products.ForEach(p => p.CategoryId = category.Id);

			dbContext.Products.AddRange(products);

            dbContext.SaveChanges();
        }
	}


    public IActionResult Index() => View();
}
