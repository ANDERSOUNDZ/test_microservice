using user_service.webapi.host.extensions;

namespace user_service.webapi.host
{
    /// <summary>
    /// Clase estática que contiene métodos de extensión para la configuración del WebApplication.
    /// Centraliza la orquestación de la Arquitectura Hexagonal y el pipeline de middleware.
    /// </summary>
    public static class HostExtensions
    {
        /// <summary>
        /// Configura todos los servicios necesarios para el funcionamiento del microservicio.
        /// Agrupa las capas de persistencia, lógica de negocio y comunicación externa.
        /// </summary>
        /// <param name="builder">El constructor de la aplicación web.</param>
        /// <returns>El constructor configurado para encadenamiento de métodos.</returns>
        public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
        {
            var services = builder.Services;
            var config = builder.Configuration;
            // Registro por módulos para mantener la modularidad y escalabilidad
            services.AddDatabaseSetup(config);
            services.AddSwaggerDocumentation();
            services.AddRepositories();
            services.AddUseCases();
            services.AddExternalClients(config);
            services.AddValidators();
            services.AddControllers();
            return builder;
        }

        /// <summary>
        /// Configura el pipeline de procesamiento de solicitudes HTTP (Middleware).
        /// Activa características como Swagger en desarrollo y el mapeo de controladores.
        /// </summary>
        /// <param name="app">La instancia de la aplicación construida.</param>
        /// <returns>La aplicación configurada.</returns>
        public static WebApplication UseHexagonal(this WebApplication app)
        {
            // Asegura que la base de datos esté actualizada al iniciar
            app.ApplyMigrations();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger(options =>
                {
                    options.RouteTemplate = "swagger/{documentName}/swagger.json";
                });

                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
                });
            }
            app.UseAuthorization();
            app.MapControllers();
            return app;
        }
    }
}
