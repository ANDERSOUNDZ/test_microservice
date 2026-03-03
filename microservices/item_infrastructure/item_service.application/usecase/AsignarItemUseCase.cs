using item_service.domain.entities;
using item_service.ports.dto.item;

namespace item_service
{
    public partial class ItemUseCase : IItemUseCase
    {
        /// <summary>
        /// Orquesta la creación y asignación inteligente de una tarea.
        /// Integra datos locales de carga con datos remotos del microservicio de Usuarios.
        /// </summary>
        /// <returns>Nombre del usuario al que se le asignó la tarea.</returns>
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

        /// <summary>
        /// Algoritmo de balanceo de carga.
        /// Reglas: 
        /// 1. Excluye usuarios con 3 o más tareas de alta relevancia.
        /// 2. Si es urgente (<3 días), elige al que tenga menos pendientes totales.
        /// 3. Si no es urgente, prioriza no exceder 5 tareas totales.
        /// </summary>
        private string CalcularDistribucion(CrearItemRequest item, List<ResumenUsuario> usuarios)
        {
            if (!usuarios.Any()) throw new Exception("No hay usuarios disponibles.");

            var candidatosNoSaturados = usuarios.Where(u => u.TotalAltaRelevancia < 3).ToList();

            if (!candidatosNoSaturados.Any())
                throw new Exception("Todos los usuarios están saturados con tareas de alta relevancia.");

            bool esUrgente = (item.FechaEntrega - DateTime.Now).TotalDays < 3;

            if (esUrgente)
            {
  
                return candidatosNoSaturados
                    .OrderBy(u => u.TotalPendientes)
                    .ThenBy(u => u.Username)
                    .First().Username;
            }
            return candidatosNoSaturados
                .OrderBy(u => u.TotalPendientes >= 5) 
                .ThenBy(u => u.TotalPendientes)
                .ThenBy(u => u.Username)
                .First().Username;
        }
    }
}
