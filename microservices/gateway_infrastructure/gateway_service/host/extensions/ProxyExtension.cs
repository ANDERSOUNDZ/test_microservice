namespace gateway_service.host.extensions
{
    /// <summary>
    /// Configuración del Proxy Inverso basado en YARP.
    /// </summary>
    public static class ProxyExtension
    {
        /// <summary>
        /// Carga la configuración de rutas y clusters desde el archivo appsettings.json.
        /// </summary>
        public static IServiceCollection AddCustomProxy(this IServiceCollection services, IConfiguration config)
        {
            services.AddReverseProxy()
                .LoadFromConfig(config.GetSection("ReverseProxy"));

            return services;
        }

        /// <summary>
        /// Habilita el middleware del proxy y mapea los endpoints.
        /// </summary>
        public static IApplicationBuilder UseCustomProxy(this IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapReverseProxy();
            });

            return app;
        }
    }
}
