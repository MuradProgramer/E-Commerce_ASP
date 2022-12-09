namespace ECommerce.ViewModels;

public abstract record BaseProductViewModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
}

public record ProductViewModel(int Id, string CategoryName, string ImageUrl) : BaseProductViewModel;

public record CreateProductViewModel(int CategoryId, IFormFile Image, int[] tagIds) : BaseProductViewModel;
