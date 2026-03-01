using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace user_service.data.context
{
    internal class UserDbContextFactory
    {
        public UserDbContext CreateDbContext(string[] args)
        {
            var apiProjectPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "../user_service.webapi.host"));

            var configuration = new ConfigurationBuilder()
                .SetBasePath(apiProjectPath)
                .AddJsonFile("appsettings.json", optional: false)
                .AddJsonFile("appsettings.Development.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' no encontrada.");

            var optionsBuilder = new DbContextOptionsBuilder<UserDbContext>();

            optionsBuilder.UseNpgsql(connectionString, npgsql =>
            {
                npgsql.MigrationsAssembly("user_service.data");
            });

            return new UserDbContext(optionsBuilder.Options);
        }
    }
}
