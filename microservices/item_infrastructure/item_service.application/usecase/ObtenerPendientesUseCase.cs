
using item_service.ports.dto.item;

namespace item_service
{
    public partial class ItemUseCase : IItemUseCase
    {
        public async Task<List<ItemPendienteResponse>> ExecuteAsync(string username)
        {
            var lista = await _itemRepository.ObtenerPendientesPorUsuarioAsync(username);

            return lista
                .OrderByDescending(x => x.EsAltaRelevancia)
                .ThenBy(x => x.FechaEntrega)
                .Select(x => new ItemPendienteResponse(
                    x.Id, x.Titulo, x.FechaEntrega.ToString("yyyy-MM-dd"), x.EsAltaRelevancia, x.UsuarioAsignado, x.Estado))
                .ToList();
        }
    }
}
