namespace ECommerce.Models.Concrete;

public class Tag: Entity
{
    public string Title { get; set; }
    
    public virtual ICollection<ProductTag> ProductTags { get; set; }


    public Tag() { }

    public Tag(string title)
    {
        Title = title;
    }
}
