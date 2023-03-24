using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProductApp.Domain.Entities;

namespace ProductApp.Persistence.EntityTypeConfigurations
{
    public class CategoryFieldsConfiguration : IEntityTypeConfiguration<CategoryField>
    {
        public void Configure(EntityTypeBuilder<CategoryField> builder)
        {
            // id
            builder.HasKey(cf => cf.Id);
            builder.Property(cf => cf.Id)
                .HasColumnName("id");

            // Name
            builder.Property(cf => cf.Name)
                .IsRequired()
                .HasColumnName("name");

            // Description
            builder.Property(cf => cf.Description)
                .HasColumnName("description");

            // Categories
            builder.HasOne(cf => cf.Category)
            .WithMany(c => c.CategoryFields)
            .HasForeignKey(cf => cf.CategoryId);

            builder.Property(cf => cf.CategoryId)
                .HasColumnName("category_id");

            // table name
            builder.ToTable("category_fields");
        }
    }
}
