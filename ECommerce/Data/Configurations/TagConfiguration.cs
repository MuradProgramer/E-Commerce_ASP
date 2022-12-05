namespace ECommerce.Data.Configurations;

public class TagConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        var tags = new List<Tag>()
        {
            new Tag("New") { Id = 1 },
            new Tag("Old") { Id = 2 }
        };

        builder.HasData(tags);
    }
}
