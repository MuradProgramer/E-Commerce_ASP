namespace ECommerce.ViewModels;

public abstract record BaseProductViewModel
{
    public string Title { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
}

public record ProductViewModel(string CategoryName, int Id) : BaseProductViewModel;

public record CreateProductViewModel(int CategoryId) : BaseProductViewModel;
