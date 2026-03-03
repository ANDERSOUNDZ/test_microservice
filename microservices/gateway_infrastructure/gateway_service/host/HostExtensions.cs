using gateway_service.host.extensions;

namespace gateway_service.host
{
    /// <summary>
    /// Extensiones para la configuración del host del Gateway.
    /// Centraliza la seguridad, el proxy y la agregación de Swagger.
    /// </summary>
    public static class HostExtensions
    {
        /// <summary>
        /// Registra los servicios de infraestructura para el Gateway, incluyendo Proxy y CORS.
        /// </summary>
        public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
        {
            var services = builder.Services;
            var config = builder.Configuration;
            services.AddCorsConfiguration(config);
            services.AddCustomProxy(config);
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            return builder;
        }

        /// <summary>
        /// Configura el pipeline de ejecución, integrando las políticas de CORS y el mapeo del Proxy.
        /// </summary>
        public static WebApplication UseHexagonal(this WebApplication app)
        {
            var corsPolicyName = app.Services.GetRequiredService<string>();
            app.UseCors(corsPolicyName);
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/api/users-service/swagger/v1/swagger.json", "Users Microservice v1");
                    options.SwaggerEndpoint("/api/items-service/swagger/v1/swagger.json", "Items Microservice v1");
                    options.RoutePrefix = "swagger";
                });
            }
            app.UseCustomProxy();
            return app;
        }
    }
}
