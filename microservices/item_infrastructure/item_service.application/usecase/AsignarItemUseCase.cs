using item_service.domain.entities;
using item_service.ports.dto.item;

namespace item_service
{
    public partial class ItemUseCase : IItemUseCase
    {
        public async Task<string> ExecuteAsync(CrearItemRequest request)
        {
            var cargaLocal = await _itemRepository.ObtenerCargaTrabajoUsuariosAsync();
            var todosLosUsernames = await _userClient.ObtenerUsernamesDisponibles();

            var cargaTotalParaAlgoritmo = todosLosUsernames.Select(username => {
                var carga = cargaLocal.FirstOrDefault(c => c.Username == username);
                return carga ?? new ResumenUsuario { Username = username, TotalPendientes = 0, TotalAltaRelevancia = 0 };
            }).ToList();

            string usuarioElegido = CalcularDistribucion(request, cargaTotalParaAlgoritmo);

            if (string.IsNullOrEmpty(usuarioElegido))
                throw new Exception("No hay usuarios disponibles o todos están saturados (>3 tareas de alta relevancia).");

            var entidad = new ItemTrabajoEntity
            {
                Id = Guid.NewGuid(),
                Titulo = request.Titulo.Trim(),
                FechaEntrega = request.FechaEntrega.ToUniversalTime(),
                EsAltaRelevancia = request.EsAltaRelevancia,
                Estado = "Pendiente",
                UsuarioAsignado = usuarioElegido
            };

            await _itemRepository.GuardarItemAsync(entidad);

            return usuarioElegido;
        }

        private string CalcularDistribucion(CrearItemRequest item, List<ResumenUsuario> usuarios)
        {
            if (!usuarios.Any()) throw new Exception("No hay usuarios disponibles.");

            var candidatosNoSaturados = usuarios.Where(u => u.TotalAltaRelevancia < 3).ToList();

            if (!candidatosNoSaturados.Any())
                throw new Exception("Todos los usuarios están saturados con tareas de alta relevancia.");

            bool esUrgente = (item.FechaEntrega - DateTime.Now).TotalDays < 3;

            if (esUrgente)
            {
                return candidatosNoSaturados.OrderBy(u => u.TotalPendientes).First().Username;
            }

            return candidatosNoSaturados.OrderBy(u => u.TotalPendientes).First().Username;
        }
    }
}
