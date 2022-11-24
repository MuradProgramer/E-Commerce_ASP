namespace ECommerce.Models.Concrete;

public class Product : Entity
{
    public string Title { get; set; }

    public string Description { get; set; }

    public ushort Price { get; set; }

    public int? CategoryId { get; set; }

    public Category? Category { get; set; }
}
