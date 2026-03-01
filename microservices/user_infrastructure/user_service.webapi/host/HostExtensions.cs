using user_service.webapi.host.extensions;

namespace user_service.webapi.host
{
    public static class HostExtensions
    {
        public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
        {
            var services = builder.Services;
            var config = builder.Configuration;
            services.AddDatabaseSetup(config);
            services.AddSwaggerDocumentation();
            services.AddRepositories();
            services.AddUseCases();
            services.AddValidators();
            services.AddControllers();
            return builder;
        }

        public static WebApplication UseHexagonal(this WebApplication app)
        {
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
