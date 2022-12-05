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
            new Product("iPhone 11", "128 GB Black", 1399.99, "b8c9431b-955b-4bd1-bcae-8042363760a3.webp") { Id = 1 },
            new Product("Samsung Galaxy A53", "128 GB 5G Blue", 899.99, "129286e1-1805-4a45-965a-690bd84f81fa.webp") { Id = 2 },
            new Product("Xiaomi Redmi Note 11 Pro", "5G 6/64 GB Graphite Gray", 749.99, "23e5f02d-5f21-4358-9f17-d1d1d76d149f.webp") { Id = 3 },
            new Product("iPhone 13", "128 GB Midnight", 1999.99, "c4c04ec2-d56c-42b1-b959-d53f980ac130.webp") { Id = 4 },
            new Product("Xiaomi 12 Lite", "8/128 GB Pink", 949.99, "98b1ad68-d2d5-465a-b1b9-73996e47c200.webp") { Id = 5 },
        };

        products.ForEach(p => p.CategoryId = 1) ;

        builder.HasData(products);
    }
}
