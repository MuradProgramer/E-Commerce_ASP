namespace ECommerce.ViewModels;

public abstract record BaseTagViewModel
{
    public string Title { get; set; }
}

public record TagViewModel(int Id) : BaseTagViewModel;
