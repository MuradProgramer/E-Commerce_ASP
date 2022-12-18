namespace ECommerce.Models.Concrete;

public class Order: Entity
{
    public string CustomerName { get; set; }
    public DateTime Time { get; set; }
    public ICollection<ProductOrder> ProductOrders { get; set; }
}
