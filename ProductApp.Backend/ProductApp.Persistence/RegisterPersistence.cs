using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProductApp.Domain.Interfaces;
using ProductApp.Persistence.Repositories;

namespace ProductApp.Persistence
{
    public static class RegisterPersistence
    {
        public static IServiceCollection ConnectDatabase(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ProductsDbContext>(options => {
                options.UseNpgsql(connectionString);
            });

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped <ICategoryFieldRepository, CategoryFieldRepository>();

            return services;
        }
    }
}
