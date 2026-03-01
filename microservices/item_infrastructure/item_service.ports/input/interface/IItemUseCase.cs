
using item_service.ports.dto.item;

namespace item_service
{
    public partial interface IItemUseCase
    {
        Task ExecuteAsync(CrearItemRequest request);
        Task ExecuteAsync(CompletarItemRequest request);
        Task<List<ItemPendienteResponse>> ExecuteAsync(string username);
    }
}
