namespace ECommerce.Models.Concrete;

public class Category : Entity
{
    public string Name { get; set; }
   
    public string ImageUrl { get; set; }

    public virtual ICollection<Product> Products { get; set; }


    public Category() { }

    public Category(string name, string imageUrl)
    {
        Name = name;
        ImageUrl = imageUrl;
    }
}
