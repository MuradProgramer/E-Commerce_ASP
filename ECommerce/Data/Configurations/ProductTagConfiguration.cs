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
    }
}
