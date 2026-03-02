using item_service.data.context;
using Microsoft.EntityFrameworkCore;

namespace item_service.webapi.host.extensions
{
    public static class MigrationExtension
    {
        public static WebApplication ApplyMigrations(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<ItemDbContext>();
                    if (context.Database.GetPendingMigrations().Any())
                    {
                        context.Database.Migrate();
                    }
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "Error aplicando migraciones en Item Service");
                }
            }
            return app;
        }
    }
}
