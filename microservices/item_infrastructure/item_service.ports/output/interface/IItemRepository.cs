
using item_service.domain.entities;
using item_service.ports.dto.item;

namespace item_service
{
    /// <summary>
    /// Puerto de salida para la persistencia de ítems de trabajo.
    /// </summary>
    public partial interface IItemRepository
    {
        /// <summary>Busca un ítem por su identificador único.</summary>
        Task<ItemTrabajoEntity?> ObtenerPorIdAsync(Guid id);

        /// <summary>Obtiene un resumen de la cantidad de tareas por cada usuario.</summary>
        Task<List<ResumenUsuario>> ObtenerCargaTrabajoUsuariosAsync();

        /// <summary>Obtiene tareas pendientes de un usuario específico.</summary>
        Task<List<ItemTrabajoEntity>> ObtenerPendientesPorUsuarioAsync(string username);

        /// <summary>Obtiene la colección de ítems con estado pendiente asignados a un usuario.</summary>
        Task<List<ItemTrabajoEntity>> ObtenerTodosAsync();

        /// <summary>Actualiza el estado o la información de un ítem existente en el almacén de datos.</summary>
        Task ActualizarItemAsync(ItemTrabajoEntity item);

        /// <summary>Guarda un nuevo ítem en la base de datos.</summary>
        Task GuardarItemAsync(ItemTrabajoEntity item);
    }
}
