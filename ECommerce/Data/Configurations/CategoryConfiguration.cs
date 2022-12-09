namespace ECommerce.Data.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        var categories = new List<Category>()
        {
            new Category("Jacket", "jacket.svg") { Id = 1 },
            new Category("Watch", "watch.svg") { Id = 2 },
            new Category("T-Shirt", "tee.svg") { Id = 3 },
            new Category("Shoes", "shoes.svg") { Id = 4 },
            new Category("Hat", "hat.svg") { Id = 5 }
        };

        builder.HasData(categories);
    }
}
