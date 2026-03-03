namespace user_service.webapi.host.extensions
{
    /// <summary>
    /// Configuración de adaptadores de salida para la comunicación con microservicios externos.
    /// Implementa el patrón Typed Client para mejorar la gestión del ciclo de vida de HttpClient.
    /// </summary>
    public static class HttpClientExtension
    {
        /// <summary>
        /// Registra los clientes HTTP necesarios para la orquestación entre servicios.
        /// </summary>
        public static IServiceCollection AddExternalClients(this IServiceCollection services, IConfiguration config)
        {
            var itemUrl = config["ExternalServices:ItemServiceUrl"] ?? "http://item_api:8080/";

            services.AddHttpClient<IItemClient, ItemClient>(client =>
            {
                client.BaseAddress = new Uri(itemUrl);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });
            return services;
        }
    }
}
