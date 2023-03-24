using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProductApp.Domain.Entities;

namespace ProductApp.Persistence.EntityTypeConfigurations
{
    public class CategoriesConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // id
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .HasColumnName("id");

            // Name
            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnName("name");

            // Description
            builder.Property(c => c.Description)
                .HasColumnName("description");

            // Categories
            builder.HasMany(c => c.CategoryFields)
            .WithOne(cf => cf.Category);

            // table name
            builder.ToTable("categories");
        }
    }
}
