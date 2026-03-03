using item_service.webapi.host.extensions;

namespace item_service.webapi.host
{
    /// <summary>
    /// Provee métodos de extensión para simplificar la configuración del Host y el Pipeline de ASP.NET Core.
    /// Centraliza el registro de componentes de la Arquitectura Hexagonal.
    /// </summary>
    public static class HostExtensions
    {
        /// <summary>
        /// Registra de forma modular todas las capas del microservicio: Datos, Negocio e Infraestructura.
        /// </summary>
        /// <param name="builder">Constructor de la aplicación web.</param>
        /// <returns>El constructor con los servicios inyectados.</returns>
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
        /// Define el comportamiento del pipeline de solicitudes HTTP.
        /// Configura Swagger, Migraciones automáticas y ruteo de controladores.
        /// </summary>
        /// <param name="app">La aplicación web construida.</param>
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
