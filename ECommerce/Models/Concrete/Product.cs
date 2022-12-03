namespace ECommerce.Models.Concrete;

public class Product : Entity
{
    public string Title { get; set; }

    public string Description { get; set; }

    public double Price { get; set; }

    public int? CategoryId { get; set; }

    public Category? Category { get; set; }


    public Product() { }

    public Product(string title, string description, double price)
    {
        Title = title;
        Description = description;
        Price = price;
    }
}
