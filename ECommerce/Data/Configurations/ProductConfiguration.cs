namespace ECommerce.Data.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.SetNull);

        var products = new List<Product>()
        {
            new Product(".", "Mens Winter Leathers Jackets", 32, "jacket-1.jpg") { Id = 1, CategoryId = 1 },
            new Product(".", "Mens Winter Leathers Jackets", 48, "jacket-2.jpg") { Id = 2, CategoryId = 1 },
            new Product(".", "Smart watche Vital Plus", 100, "watch-1.jpg") { Id = 3, CategoryId = 2 },
            new Product(".", "Pocket Watch Leather Pouch", 150, "watch-3.jpg") { Id = 4, CategoryId = 2 },
            new Product(".", "Pure Garment Dyed Cotton Shirt", 45, "shirt-1.jpg") { Id = 5, CategoryId = 3 },
            new Product(".", "Casual Men's Brown shoes", 45, "shoe-2.jpg") { Id = 6, CategoryId = 4 },
            new Product(".", "Men's Leather Formal Wear shoes", 50, "shoe-1.jpg") { Id = 7, CategoryId = 4 }
        };

        builder.HasData(products);
    }
}
