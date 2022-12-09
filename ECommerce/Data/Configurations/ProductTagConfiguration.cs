namespace ECommerce.Data.Configurations;

public class ProductTagConfiguration : IEntityTypeConfiguration<ProductTag>
{
    public void Configure(EntityTypeBuilder<ProductTag> builder)
    {
        builder.HasKey(pt => new { pt.ProductId, pt.TagId });

        builder.HasOne(pt => pt.Product)
            .WithMany(p => p.ProductTags)
            .HasForeignKey(pt => pt.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(pt => pt.Tag)
            .WithMany(t => t.ProductTags)
            .HasForeignKey(pt => pt.TagId)
            .OnDelete(DeleteBehavior.Cascade);


        var productTags = new List<ProductTag>()
        {
            new ProductTag(2, 1),
            new ProductTag(4, 1),
            new ProductTag(7, 1),
            new ProductTag(3, 2),
            new ProductTag(6, 3),
        };

        builder.HasData(productTags);
    }
}
