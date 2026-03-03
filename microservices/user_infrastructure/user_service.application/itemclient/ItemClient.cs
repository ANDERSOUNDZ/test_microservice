
using System.Net.Http.Json;
using user_service.ports.dto.settings;

namespace user_service
{
    /// <summary>
    /// Adaptador de infraestructura para la comunicación vía HTTP con el servicio de ítems.
    /// Utiliza <see cref="HttpClient"/> para realizar las peticiones externas.
    /// </summary>
    public partial class ItemClient: IItemClient
    {
        /// <summary>
        /// Realiza una petición GET al endpoint de pendientes del microservicio de ítems.
        /// </summary>
        /// <param name="username">El username del usuario.</param>
        /// <returns>Resultado booleano basado en la respuesta de la API externa.</returns>
        /// <exception cref="Exception">Lanzada cuando la comunicación con el servicio externo falla.</exception>
        public async Task<bool> UsuarioTieneTareasPendientesAsync(string username)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<ApiResponse<List<object>>>($"pendientes/{username}");

                return response != null && response.Success && response.Data != null && response.Data.Any();
            }
            catch (Exception)
            {
                throw new Exception("No se pudo verificar la carga de trabajo en el Servicio de Ítems.");
            }
        }
    }
}
