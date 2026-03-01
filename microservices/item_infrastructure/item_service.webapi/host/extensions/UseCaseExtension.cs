namespace item_service.webapi.host.extensions
{
    public static class UseCaseExtension
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<IItemUseCase, ItemUseCase>();
            return services;
        }
    }
}
