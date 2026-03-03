namespace item_service.webapi.host.extensions
{
    /// <summary>
    /// Configuración de los adaptadores de salida para servicios externos.
    /// Registra clientes HTTP tipados para garantizar el desacoplamiento entre microservicios.
    /// </summary>
    public static class HttpClientExtension
    {
        /// <summary>
        /// Registra e inicializa el cliente HTTP para la comunicación con el microservicio de Usuarios.
        /// </summary>
        public static IServiceCollection AddExternalClients(this IServiceCollection services, IConfiguration config)
        {
            var userUrl = config["ExternalServices:UserServiceUrl"] ?? "http://user_api:8080/";

            services.AddHttpClient<IUserClient, UserClient>(client =>
            {
                client.BaseAddress = new Uri(userUrl);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });
            return services;
        }
    }
}
