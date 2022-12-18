namespace ECommerce.Models.Concrete;

public class ProductOrder
{
    public int ProductId { get; set; }
    public virtual Product Product { get; set; }

    public int OrderId { get; set; }
    public virtual Order Order { get; set; }

    public int Count { get; set; }

    public ProductOrder(int productId, int orderId, int count = 0)
    {
        ProductId = productId;
        OrderId = orderId;
        Count = count;
    }
}
