namespace user_service.webapi.host.extensions
{
    /// <summary>
    /// Orquestador de inyección de dependencias para la capa de infraestructura/datos.
    /// </summary>
    public static class RepositoryExtension
    {
        /// <summary>
        /// Registra las implementaciones de los repositorios bajo sus interfaces (Puertos de Salida).
        /// </summary>
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
