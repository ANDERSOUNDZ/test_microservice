using Microsoft.OpenApi.Models;

namespace user_service.webapi.host.extensions
{
    public static class SwaggerExtension
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "User Services",
                    Version = "v1",
                    Description = "Documentación de la API de User Services",
                    Contact = new OpenApiContact
                    {
                        Name = "Anderson Chanchay",
                        Email = "andersonmikol@live.com"
                    }
                });
                options.AddServer(new OpenApiServer { Url = "/api/users-service" });
            });
            return services;
        }
    }
}
