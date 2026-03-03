
using item_service.ports.dto.item;
using item_service.ports.dto.settings;
using System.Net.Http.Json;

namespace item_service
{
    public partial class UserClient : IUserClient
    {
        /// <summary>
        /// Consulta al microservicio de usuarios para obtener la lista de nombres de usuario disponibles.
        /// </summary>
        /// <returns>Lista de strings con los nombres de usuario o una lista vacía si no hay respuesta.</returns>
        public async Task<List<string>> ObtenerUsernamesDisponibles()
        {
            // Se asume que el endpoint "listar" devuelve la información básica de usuarios
            var response = await _httpClient.GetFromJsonAsync<ApiResponse<List<UsuarioResumen>>>("listar");

            return response?.Data?.Select(u => u.Username).ToList() ?? new List<string>();
        }
    }
}
