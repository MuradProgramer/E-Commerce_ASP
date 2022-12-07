namespace ECommerce.Data.Configurations;

public class TagConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        var tags = new List<Tag>()
        {
            new Tag("Newer") { Id = 1 },
            new Tag("Older") { Id = 2 }
        };

        builder.HasData(tags);
    }
}
