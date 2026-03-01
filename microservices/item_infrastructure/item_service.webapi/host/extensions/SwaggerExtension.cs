using Microsoft.OpenApi.Models;

namespace item_service.webapi.host.extensions
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
                    Title = "Item Services",
                    Version = "v1",
                    Description = "Documentación de la API de Item Services",
                    Contact = new OpenApiContact
                    {
                        Name = "Anderson Chanchay",
                        Email = "andersonmikol@live.com"
                    }
                });
                options.AddServer(new OpenApiServer { Url = "/api/items-service" });
            });
            return services;
        }
    }
}