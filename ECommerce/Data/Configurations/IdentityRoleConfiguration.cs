namespace ECommerce.Data.Configurations;

public class IdentityRoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    private const string _adminId = "2301D884-221A-4E7D-B509-0113DCC043E1";
    private const string _clientId = "80a48861-ef5d-4d3d-861f-7566e59b7b82";

    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        var roles = new List<IdentityRole>()
        {
          new IdentityRole()
          {
              Id = _adminId,
              Name = "Administrator",
              NormalizedName = "ADMINISTRATOR"
          },
          new IdentityRole()
          {
              Id = _clientId,
              Name = "Client",
              NormalizedName = "CLIENT"
          }
        };

        builder.HasData(roles);
    }
}
