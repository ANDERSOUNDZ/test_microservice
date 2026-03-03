using item_service.ports.dto.item;

namespace item_service
{
    public partial class ItemUseCase : IItemUseCase
    {
        /// <summary>
        /// Cambia el estado de una tarea a 'Completado'.
        /// </summary>
        /// <param name="request">DTO con el ID del ítem.</param>
        public async Task ExecuteAsync(CompletarItemRequest request)
        {
            var item = await _itemRepository.ObtenerPorIdAsync(request.ItemId);
            if (item == null) throw new Exception("Ítem no encontrado.");

            item.Estado = "Completado";
            await _itemRepository.ActualizarItemAsync(item);
        }
    }
}
