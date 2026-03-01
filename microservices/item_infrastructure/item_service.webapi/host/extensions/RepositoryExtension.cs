namespace item_service.webapi.host.extensions
{
    public static class RepositoryExtension
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IItemRepository, ItemRepository>();
        }
    }
}
