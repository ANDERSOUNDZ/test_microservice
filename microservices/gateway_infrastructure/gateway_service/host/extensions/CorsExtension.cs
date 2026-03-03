namespace gateway_service.host.extensions
{
    public static class CorsExtension
    {
        /// <summary>
        /// Extensión para la configuración centralizada de las políticas de intercambio de recursos de origen cruzado (CORS).
        /// Garantiza que el Gateway solo acepte peticiones de dominios autorizados.
        /// </summary>
        public static IServiceCollection AddCorsConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            /// <summary>
            /// Configura las políticas de CORS basándose en la configuración del sistema.
            /// Registra el nombre de la política como un Singleton para su uso en el pipeline de middleware.
            /// </summary>
            /// <param name="services">Colección de servicios para la inyección de dependencias.</param>
            /// <param name="configuration">Configuración de la aplicación para extraer los orígenes permitidos.</param>
            /// <returns>La colección de servicios con CORS configurado.</returns>
            string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
            // Intenta obtener la lista de orígenes desde el appsettings.json
            var allowedOrigins = configuration.GetSection("Cors:AllowedOrigins").Get<string[]>() ?? Array.Empty<string>();

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                    builder =>
                    {
                        if (allowedOrigins.Any())
                        {
                            // Configuración restrictiva para entornos de producción
                            builder.WithOrigins(allowedOrigins)
                                .AllowAnyHeader()
                                .AllowAnyMethod()
                                .AllowCredentials();
                        }
                        else
                        {
                            // Configuración abierta (usualmente solo para desarrollo inicial)
                            builder.AllowAnyOrigin()
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                        }
                    });
            });
            services.AddSingleton(MyAllowSpecificOrigins);
            return services;
        }
    }
}
