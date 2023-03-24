using Microsoft.EntityFrameworkCore;

namespace ProductApp.Persistence.MigrationManager;

public static class MigrationManager
{
    public static WebApplication MigrateDatabase(this WebApplication host)
    {
        using (var scope = host.Services.CreateScope())
        {
            using (var appContext = scope.ServiceProvider.GetRequiredService<ProductsDbContext>())
            {
                try
                {
                    appContext.Database.Migrate();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
        return host;
    }
}
