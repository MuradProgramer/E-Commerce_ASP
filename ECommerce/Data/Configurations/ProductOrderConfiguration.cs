namespace ECommerce.Data.Configurations;

public class ProductOrderConfiguration : IEntityTypeConfiguration<ProductOrder>
{
    public void Configure(EntityTypeBuilder<ProductOrder> builder)
    {
        builder.HasKey(pt => new { pt.ProductId, pt.OrderId });

        builder.HasOne(pt => pt.Product)
            .WithMany(p => p.ProductOrders)
            .HasForeignKey(pt => pt.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(pt => pt.Order)
            .WithMany(t => t.ProductOrders)
            .HasForeignKey(pt => pt.OrderId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
