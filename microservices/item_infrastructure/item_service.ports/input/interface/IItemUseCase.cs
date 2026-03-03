
using item_service.ports.dto.item;

namespace item_service
{
    /// <summary>
    /// Puerto de entrada que define los casos de uso para la gestión de ítems.
    /// </summary>
    public partial interface IItemUseCase
    {
        /// <summary>Ejecuta la lógica de creación y asignación automática.</summary>
        Task<string> ExecuteAsync(CrearItemRequest request);

        /// <summary>Ejecuta la lógica de finalización de tarea.</summary>
        Task ExecuteAsync(CompletarItemRequest request);

        /// <summary>Ejecuta la lógica para recuperar los ítems pendientes de un usuario específico.</summary>
        Task<List<ItemPendienteResponse>> ExecuteAsync(string username);

        /// <summary>Ejecuta la lógica para recuperar el listado completo de ítems en el sistema.</summary>
        Task<List<ItemPendienteResponse>> ExecuteAsync();
    }
}
