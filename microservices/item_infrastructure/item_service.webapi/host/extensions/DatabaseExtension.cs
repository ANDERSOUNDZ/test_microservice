using item_service.data.context;
using Microsoft.EntityFrameworkCore;

namespace item_service.webapi.host.extensions
{
    /// <summary>
    /// Extensión para la configuración centralizada de la persistencia de datos.
    /// Define la conexión a PostgreSQL y las políticas de resiliencia ante fallos.
    /// </summary>
    public static class DatabaseExtension
    {        
        /// <summary>
        /// Configura el DbContext de Ítems con estrategias de reintento y logging de diagnóstico.
        /// </summary>
        /// <param name="services">Colección de servicios del contenedor de dependencias.</param>
        /// <param name="configuration">Proveedor de configuración para obtener la cadena de conexión.</param>
        /// <returns>La colección de servicios configurada.</returns>
        public static IServiceCollection AddDatabaseSetup(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ItemDbContext>(options =>
            {
                options.UseNpgsql(connectionString, npgsqlOptions =>
                {
                    npgsqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 5,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorCodesToAdd: null);

                    npgsqlOptions.MigrationsAssembly("item_service.data");
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
