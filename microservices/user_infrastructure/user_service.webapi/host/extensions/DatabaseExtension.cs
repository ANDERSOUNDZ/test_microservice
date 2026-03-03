using Microsoft.EntityFrameworkCore;
using user_service.data.context;

namespace user_service.webapi.host.extensions
{
    /// <summary>
    /// Extensión para la configuración centralizada de la base de datos.
    /// Define la resiliencia y el ensamblado de migraciones para la persistencia.
    /// </summary>
    public static class DatabaseExtension
    {
        /// <summary>
        /// Configura el DbContext con PostgreSQL, definiendo estrategias de reintento y logging detallado.
        /// </summary>
        public static IServiceCollection AddDatabaseSetup(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<UserDbContext>(options =>
            {
                options.UseNpgsql(connectionString, npgsqlOptions =>
                {
                    npgsqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 5,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorCodesToAdd: null);

                    npgsqlOptions.MigrationsAssembly("user_service.data");
                });

                options.ConfigureWarnings(w => w.Ignore(Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.PendingModelChangesWarning));

                if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
                {
                    options.EnableDetailedErrors();
                    options.EnableSensitiveDataLogging();
                }
            });

            return services;
        }
    }
}
