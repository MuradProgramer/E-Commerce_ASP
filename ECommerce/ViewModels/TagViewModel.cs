namespace ECommerce.ViewModels;

public abstract record BaseTagViewModel
{
    public string Title { get; set; }
}

public record TagViewModel(int Id) : BaseTagViewModel;

public record FilterTagViewModel(int Id, bool Checked) : BaseTagViewModel;

public record FilterTagViewModelContainer(List<FilterTagViewModel> ViewTags);
