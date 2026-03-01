using gateway_service.host.extensions;

namespace gateway_service.host
{
    public static class HostExtensions
    {
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
