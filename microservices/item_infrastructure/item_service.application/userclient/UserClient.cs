
using item_service.ports.dto.item;
using item_service.ports.dto.settings;
using System.Net.Http.Json;

namespace item_service
{
    public partial class UserClient : IUserClient
    {
        public async Task<List<string>> ObtenerUsernamesDisponiblesAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<ApiResponse<List<UsuarioResumen>>>("listar");

            return response?.Data?.Select(u => u.Username).ToList() ?? new List<string>();
        }
    }
}
