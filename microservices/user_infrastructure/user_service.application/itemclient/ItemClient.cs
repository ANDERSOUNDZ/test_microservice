
using System.Net.Http.Json;
using user_service.ports.dto.settings;

namespace user_service
{
    public partial class ItemClient: IItemClient
    {
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
