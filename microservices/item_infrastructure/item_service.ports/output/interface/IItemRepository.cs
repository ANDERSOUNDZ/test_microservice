
using item_service.domain.entities;
using item_service.ports.dto.item;

namespace item_service
{
    public partial interface IItemRepository
    {
        Task<ItemTrabajoEntity?> ObtenerPorIdAsync(Guid id);
        Task<List<ResumenUsuario>> ObtenerCargaTrabajoUsuariosAsync();
        Task<List<ItemTrabajoEntity>> ObtenerPendientesPorUsuarioAsync(string username);
        Task<List<ItemTrabajoEntity>> ObtenerTodosAsync();
        Task ActualizarItemAsync(ItemTrabajoEntity item);
        Task GuardarItemAsync(ItemTrabajoEntity item);
    }
}
