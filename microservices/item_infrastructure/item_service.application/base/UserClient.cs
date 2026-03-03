namespace item_service
{
    /// <summary>
    /// Implementación del cliente para el servicio de usuarios.
    /// Esta parte gestiona la infraestructura de comunicación vía HTTP.
    /// </summary>
    public partial class UserClient : IUserClient
    {
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="UserClient"/>.
        /// </summary>
        /// <param name="httpClient">Cliente inyectado para el consumo de la API de usuarios.</param>
        public UserClient(
            HttpClient httpClient
            )
        {
            _httpClient = httpClient;
        }
    }
}