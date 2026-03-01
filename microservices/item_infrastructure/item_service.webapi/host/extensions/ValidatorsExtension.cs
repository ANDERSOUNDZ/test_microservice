using FluentValidation;
using item_service.ports.dto.item;
using item_service.webapi.adapters.input.filters;
using item_service.webapi.adapters.input.validators;

namespace item_service.webapi.host.extensions
{
    public static class ValidatorsExtension
    {
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<CrearItemValidator>();
            services.AddScoped<ValidationFilter<CrearItemRequest>>();
            services.AddValidatorsFromAssemblyContaining<CompletarItemValidator>();
            services.AddScoped<ValidationFilter<CompletarItemRequest>>();
            return services;
        }
    }
}
