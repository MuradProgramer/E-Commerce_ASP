namespace ECommerce.Data;

public class AppDbContext : IdentityDbContext
{
    public AppDbContext(DbContextOptions options) : base(options) { }


    public DbSet<AppUser> AppUsers { get; set; }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    public DbSet<Tag> Tags { get; set; }
    public DbSet<Order> Orders { get; set; }

    public DbSet<ProductTag> ProductTags { get; set; }
    public DbSet<ProductOrder> ProductOrders { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AdminConfiguration());
        modelBuilder.ApplyConfiguration(new IdentityRoleConfiguration());
        modelBuilder.ApplyConfiguration(new UsersWithRolesConfiguration());

        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());

        modelBuilder.ApplyConfiguration(new TagConfiguration());
        modelBuilder.ApplyConfiguration(new OrderConfiguration());

        modelBuilder.ApplyConfiguration(new ProductTagConfiguration());
        modelBuilder.ApplyConfiguration(new ProductOrderConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}
