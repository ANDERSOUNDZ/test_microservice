using item_service.ports.dto.item;

namespace item_service
{
    public partial class ItemUseCase : IItemUseCase
    {
        public async Task<List<ItemPendienteResponse>> ExecuteAsync()
        {
            var items = await _itemRepository.ObtenerTodosAsync();

            return items.Select(x => new ItemPendienteResponse(
                x.Id,
                x.Titulo,
                x.FechaEntrega.ToString("yyyy-MM-dd"),
                x.EsAltaRelevancia,
                x.UsuarioAsignado
                )).ToList();
        }
    }
}
