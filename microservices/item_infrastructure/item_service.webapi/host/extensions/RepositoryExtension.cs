namespace item_service.webapi.host.extensions
{
    /// <summary>
    /// Orquestador para el registro de adaptadores de persistencia.
    /// </summary>
    public static class RepositoryExtension
    {
        /// <summary>
        /// Vincula la interfaz del repositorio con su implementación técnica (PostgreSQL).
        /// </summary>
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IItemRepository, ItemRepository>();
        }
    }
}
