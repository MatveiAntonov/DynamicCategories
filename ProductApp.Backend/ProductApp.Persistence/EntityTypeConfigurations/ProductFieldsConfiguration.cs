using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProductApp.Domain.Entities;

namespace ProductApp.Persistence.EntityTypeConfigurations
{
    public class ProductFieldsConfiguration : IEntityTypeConfiguration<ProductField>
    {
        public void Configure(EntityTypeBuilder<ProductField> builder)
        {
            // id
            builder.HasKey(pf => pf.Id);
            builder.Property(pf => pf.Id)
                .HasColumnName("id");

            // Name
            builder.Property(pf => pf.Name)
                .IsRequired()
                .HasColumnName("name");

            // Value
            builder.Property(pf => pf.Value)
                .HasColumnName("value");

            // Product   
            builder.HasOne(pf => pf.Product)
                .WithMany(p => p.ProductFields)
                .HasForeignKey(pf => pf.ProductId);

            builder.Property(pf => pf.ProductId)
                .HasColumnName("product_id");

            // table name
            builder.ToTable("product_fields");
        }
    }
}
