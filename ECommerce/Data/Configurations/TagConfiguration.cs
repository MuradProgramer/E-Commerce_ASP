namespace ECommerce.Data.Configurations;

public class TagConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        var tags = new List<Tag>()
        {
            new Tag("Newer") { Id = 1 },
        };

        builder.HasData(tags);
    }
}
