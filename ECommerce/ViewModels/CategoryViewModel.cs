namespace ECommerce.ViewModels;

public abstract record BaseCategoryViewModel
{
    public string Name { get; set; }
}

public record CategoryViewModel(int Id, string ImageUrl): BaseCategoryViewModel;

public record CreateCategoryViewModel(IFormFile Image): BaseCategoryViewModel;
