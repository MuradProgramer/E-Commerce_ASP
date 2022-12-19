namespace ECommerce.ViewModels;

public abstract record BaseProductViewModel
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public double Price { get; set; }
}

public record ProductViewModel(int Id, string CategoryName, string ImageUrl) : BaseProductViewModel;

public record CreateProductViewModel([Required] int CategoryId, [Required] IFormFile Image, int[] tagIds) : BaseProductViewModel;

public class BasketProductViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public string ImageUrl { get; set; }
    public int Count { get; set; }


    public BasketProductViewModel() { }

    public BasketProductViewModel(int ıd, string ımageUrl, int count)
    {
        Id = ıd;
        ImageUrl = ımageUrl;
        Count = count;
    }
}