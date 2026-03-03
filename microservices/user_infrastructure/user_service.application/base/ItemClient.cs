namespace user_service
{
    /// <summary>
    /// Parte de la clase ItemClient encargada de la infraestructura y dependencias técnicas.
    /// </summary>
    public partial class ItemClient
    {
        /// <summary>
        /// Inicializa el cliente HTTP para la comunicación entre microservicios.
        /// </summary>
        /// <param name="httpClient">Cliente inyectado para realizar peticiones externas.</param>
        private readonly HttpClient _httpClient;
        public ItemClient(
            HttpClient httpClient
            )
        {
            _httpClient = httpClient;
        }
    }
}
