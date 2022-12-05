namespace ECommerce.Models.Concrete;

public class ProductTag
{
    public int ProductId { get; set; }
    public Product Product { get; set; }

    public int TagId { get; set; }
    public Tag Tag { get; set; }


    public ProductTag(int productId, int tagId)
    {
        ProductId = productId;
        TagId = tagId;
    }
}
