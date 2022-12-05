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
            new Product("iPhone 11", "128 GB Black", 1399.99) { Id = 1 },
            new Product("Samsung Galaxy A53", "128 GB 5G Blue", 899.99) { Id = 2 },
            new Product("Xiaomi Redmi Note 11", "4/64 GB Star Blue", 459.99) { Id = 3 },
            new Product("iPhone 13", "128 GB Midnight", 1999.99) { Id = 4 },
            new Product("Xiaomi 12 Lite", "6/128 GB Lite Pink", 899.99) { Id = 5 },
        };

        products.ForEach(p => p.CategoryId = 1) ;

        builder.HasData(products);
    }
}
