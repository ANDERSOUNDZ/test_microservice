using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace item_service.data.context
{
    internal class ItemDbContextFactory
    {
        public ItemDbContext CreateDbContext(string[] args)
        {
            var apiProjectPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "../item_service.webapi.host"));

            var configuration = new ConfigurationBuilder()
                .SetBasePath(apiProjectPath)
                .AddJsonFile("appsettings.json", optional: false)
                .AddJsonFile("appsettings.Development.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' no encontrada.");

            var optionsBuilder = new DbContextOptionsBuilder<ItemDbContext>();

            optionsBuilder.UseNpgsql(connectionString, npgsql =>
            {
                npgsql.MigrationsAssembly("item_service.data");
            });

            return new ItemDbContext(optionsBuilder.Options);
        }
    }
}
