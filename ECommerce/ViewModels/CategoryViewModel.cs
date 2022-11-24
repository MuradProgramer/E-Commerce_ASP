namespace ECommerce.ViewModels;

public abstract record BaseCategoryViewModel
{
    public string Name { get; set; }
}

public record CategoryViewModel(int Id): BaseCategoryViewModel;
