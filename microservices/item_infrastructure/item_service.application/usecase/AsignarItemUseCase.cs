using item_service.domain.entities;
using item_service.ports.dto.item;

namespace item_service
{
    public partial class ItemUseCase : IItemUseCase
    {
        public async Task ExecuteAsync(CrearItemRequest request)
        {
            var cargaUsuarios = await _itemRepository.ObtenerCargaTrabajoUsuariosAsync();

            string usuarioElegido = CalcularDistribucion(request, cargaUsuarios);

            var entidad = new ItemTrabajoEntity
            {
                Id = Guid.NewGuid(),
                Titulo = request.Titulo,
                FechaEntrega = request.FechaEntrega,
                EsAltaRelevancia = request.EsAltaRelevancia,
                Estado = "Pendiente",
                UsuarioAsignado = usuarioElegido
            };

            await _itemRepository.GuardarItemAsync(entidad);
        }

        private string CalcularDistribucion(CrearItemRequest item, List<ResumenUsuario> usuarios)
        {
            if (!usuarios.Any()) throw new Exception("No hay usuarios disponibles para asignación.");

            bool esUrgente = (item.FechaEntrega - DateTime.Now).TotalDays < 3;
            if (esUrgente)
            {
                return usuarios.OrderBy(u => u.TotalPendientes).First().Username;
            }
            var candidatos = usuarios.Where(u => u.TotalAltaRelevancia < 3).ToList();

            if (!candidatos.Any())
                return usuarios.OrderBy(u => u.TotalPendientes).First().Username;

            return candidatos.OrderBy(u => u.TotalPendientes).First().Username;
        }
    }
}
