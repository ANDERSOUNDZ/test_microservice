using FluentValidation;
using user_service.ports.dto.user;
using user_service.webapi.adapters.input.filters;
using user_service.webapi.adapters.input.validators;

namespace user_service.webapi.host.extensions
{
    public static class ValidatorsExtension
    {
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<CrearUsuarioValidator>();
            services.AddScoped<ValidationFilter<CrearUsuarioRequest>>();
            return services;
        }
    }
}
