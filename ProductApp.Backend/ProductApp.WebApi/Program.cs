using ProductApp.Persistence;
using ProductApp.Persistence.MigrationManager;
using ProductApp.WebApi.Mappings;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors();

var services = builder.Services;

services.ConnectDatabase(builder.Configuration.GetConnectionString("ProductsDbConnection"));

services.AddControllers();

services.AddAutoMapper(typeof(MappingProfile));

var     app = builder.Build().MigrateDatabase();

app.UseRouting();

app.UseCors(builder => builder.AllowAnyOrigin());

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.MapGet("/", () => "Hello World!");

app.Run();
