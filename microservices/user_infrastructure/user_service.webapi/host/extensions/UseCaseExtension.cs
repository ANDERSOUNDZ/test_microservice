namespace user_service.webapi.host.extensions
{
    /// <summary>
    /// Orquestador de inyección de dependencias para la capa de aplicación.
    /// </summary>
    public static class UseCaseExtension
    {
        /// <summary>
        /// Registra los casos de uso (Puertos de Entrada) que contienen la lógica orquestadora.
        /// </summary>
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<IUserUseCase, UserUseCase>();
            return services;
        }
    }
}
