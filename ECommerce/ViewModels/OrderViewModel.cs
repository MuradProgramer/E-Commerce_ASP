namespace ECommerce.ViewModels;

public class OrderViewModel
{
    public string CustomerName { get; set; }
    public double Money { get; set; }
    public DateTime Time { get; set; }
    public List<BasketProductViewModel> Products { get; set; }


    public OrderViewModel(string customerName, double money, DateTime time, List<BasketProductViewModel> products)
    {
        CustomerName = customerName;
        Money = money;
        Time = time;
        Products = products;
    }
}
