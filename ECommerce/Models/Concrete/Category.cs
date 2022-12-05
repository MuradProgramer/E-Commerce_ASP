namespace ECommerce.Models.Concrete;

public class Category : Entity
{
    public string Name { get; set; }

    public virtual ICollection<Product> Products { get; set; }


    public Category() { }

    public Category(string name)
    {
        Name = name;
    }
}
