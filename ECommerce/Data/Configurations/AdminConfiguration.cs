namespace ECommerce.Data.Configurations;

public class AdminConfiguration : IEntityTypeConfiguration<AppUser>
{
    private const string _adminId = "B22698B8-42A2-4115-9631-1C2D1E2AC5F7";

    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        var admin = new AppUser
        {
            Id = _adminId,
            UserName = "masteradmin",
            NormalizedUserName = "MASTERADMIN",
            FirstName = "Master",
            LastName = "Admin",
            Email = "admin@admin.com",
            NormalizedEmail = "ADMIN@ADMIN.COM",
            PhoneNumber = "XXXXXXXXXXXXX",
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
            SecurityStamp = new Guid().ToString("D"),
        };

        admin.PasswordHash = new PasswordHasher<AppUser>().HashPassword(admin, "admin00");

        builder.HasData(admin);
    }
}
