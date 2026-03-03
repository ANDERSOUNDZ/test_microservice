namespace item_service.webapi.host.extensions
{
    /// <summary>
    /// Orquestador para el registro de los servicios de aplicación (Casos de Uso).
    /// </summary>
    public static class UseCaseExtension
    {
        /// <summary>
        /// Registra la lógica de orquestación de ítems en el contenedor de dependencias.
        /// </summary>
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<IItemUseCase, ItemUseCase>();
            return services;
        }
    }
}
