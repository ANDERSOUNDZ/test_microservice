namespace gateway_service.host.extensions
{
    public static class ProxyExtension
    {
        public static IServiceCollection AddCustomProxy(this IServiceCollection services, IConfiguration config)
        {
            services.AddReverseProxy()
                .LoadFromConfig(config.GetSection("ReverseProxy"));

            return services;
        }

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
