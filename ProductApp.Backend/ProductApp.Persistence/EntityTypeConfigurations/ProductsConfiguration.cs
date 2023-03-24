using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductApp.Domain.Entities;

namespace ProductApp.Persistence.EntityTypeConfigurations
{
    public class ProductsConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // id
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .HasColumnName("id");

            // Name
            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnName("name");

            // Description
            builder.Property(p => p.Description)
                .HasColumnName("description");

            // Price
            builder.Property(p => p.Price)
                .IsRequired()
                .HasColumnName("price");

            // CategoryId
            builder.HasOne(p => p.Category)
            .WithMany()
            .HasForeignKey(p => p.CategoryId);

            builder.Property(cmp => cmp.CategoryId)
                .HasColumnName("category_id");

            // table name
            builder.ToTable("products");
        }   
    }
}
