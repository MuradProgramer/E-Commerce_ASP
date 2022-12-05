namespace ECommerce.Data.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasData(new Category("Smartphone") { Id = 1 });
    }
}
