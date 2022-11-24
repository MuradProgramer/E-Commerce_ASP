namespace ECommerce.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options) { }


    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany(p => p.Products)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
