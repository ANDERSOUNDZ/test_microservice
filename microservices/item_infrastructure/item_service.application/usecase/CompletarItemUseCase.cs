using item_service.ports.dto.item;

namespace item_service
{
    public partial class ItemUseCase : IItemUseCase
    {
        public async Task ExecuteAsync(CompletarItemRequest request)
        {
            var item = await _itemRepository.ObtenerPorIdAsync(request.ItemId);
            if (item == null) throw new Exception("Ítem no encontrado.");

            item.Estado = "Completado";
            await _itemRepository.ActualizarItemAsync(item);
        }
    }
}
