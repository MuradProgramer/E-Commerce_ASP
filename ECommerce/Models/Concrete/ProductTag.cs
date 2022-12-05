namespace ECommerce.Models.Concrete;

public class ProductTag
{
    public int ProductId { get; set; }
    public virtual Product Product { get; set; }

    public int TagId { get; set; }
    public virtual Tag Tag { get; set; }


    public ProductTag(int productId, int tagId)
    {
        ProductId = productId;
        TagId = tagId;
    }
}
