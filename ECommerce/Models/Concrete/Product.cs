namespace ECommerce.Models.Concrete;

public class Product : Entity
{
    public string Name { get; set; }

    public string Description { get; set; }

    public double Price { get; set; }

    public string ImageUrl { get; set; }

    public int? CategoryId { get; set; }
    public virtual Category? Category { get; set; }

    public virtual ICollection<ProductTag> ProductTags { get; set; }
    public virtual ICollection<ProductOrder> ProductOrders { get; set; }


    public Product() { }

    public Product(string name, string description, double price, string imageUrl)
    {
        Name = name;
        Description = description;
        Price = price;
        ImageUrl = imageUrl;
    }
}
