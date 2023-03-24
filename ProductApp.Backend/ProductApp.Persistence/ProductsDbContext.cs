using Microsoft.EntityFrameworkCore;
using ProductApp.Domain.Entities;
using ProductApp.Persistence.EntityTypeConfigurations;

namespace ProductApp.Persistence
{
    public class ProductsDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryField> CategoryFields { get; set; }
        public DbSet<ProductField> ProductFields { get; set; }


        public ProductsDbContext(DbContextOptions<ProductsDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CategoriesConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryFieldsConfiguration());
            modelBuilder.ApplyConfiguration(new ProductsConfiguration());
            modelBuilder.ApplyConfiguration(new ProductFieldsConfiguration());

        }

    }
}
