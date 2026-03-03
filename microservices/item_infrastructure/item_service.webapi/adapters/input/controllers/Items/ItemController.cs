using item_service.ports.dto.item;
using item_service.ports.shared.enums;
using item_service.webapi.adapters.input.filters;
using Microsoft.AspNetCore.Mvc;

namespace item_service.webapi.adapters.input.controllers.Items
{
    /// <summary>
    /// Adaptador de entrada (Controlador API) para la gestión de ítems de trabajo.
    /// Orquesta las peticiones HTTP hacia los casos de uso de la capa de aplicación.
    /// </summary>
    [Route("/")]
    [ApiController]
    public class ItemController : BaseController
    {        
        private readonly IItemUseCase _executor;

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="ItemController"/>.
        /// </summary>
        /// <param name="executor">Puerto de entrada para la lógica de ítems.</param>
        public ItemController(IItemUseCase executor)
        {
            _executor = executor;
        }

        /// <summary>
        /// Obtiene los ítems con estado pendiente para un usuario específico.
        /// </summary>
        /// <param name="username">Nombre de usuario a consultar.</param>
        /// <returns>Lista de ítems pendientes.</returns>
        [HttpGet("pendientes/{username}")]
        public async Task<IActionResult> ListarPendientes(string username)
        {
            try
            {
                var data = await _executor.ExecuteAsync(username);
                return OkResponse(data, ApiMessage.OperationSuccess);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        /// <summary>
        /// Obtiene el listado completo de todos los ítems de trabajo registrados en el sistema.
        /// </summary>
        /// <returns>Una respuesta exitosa con la colección de todos los ítems o un error interno.</returns>
        [HttpGet("listar-todo")]
        public async Task<IActionResult> ListarTodo()
        {
            try
            {
                var data = await _executor.ExecuteAsync();
                return OkResponse(data, ApiMessage.OperationSuccess);
            }
            catch (Exception ex) { return InternalErrorResponse(ex); }
        }

        /// <summary>
        /// Crea y asigna un nuevo ítem de trabajo según las reglas de negocio.
        /// </summary>
        /// <param name="request">DTO con los detalles del ítem.</param>
        /// <returns>Confirmación de creación y el usuario al que fue asignado.</returns>
        [HttpPost("asignar")]
        [ServiceFilter(typeof(ValidationFilter<CrearItemRequest>))]
        public async Task<IActionResult> CrearItem([FromBody] CrearItemRequest request)
        {
            try
            {
                string asignado = await _executor.ExecuteAsync(request);
                return OkResponse(true, ApiMessage.TaskSuccessfullyCompleted, asignado);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        /// <summary>
        /// Marca un ítem de trabajo como completado.
        /// </summary>
        /// <param name="request">DTO con el ID del ítem a completar.</param>
        [HttpPatch("completar")]
        [ServiceFilter(typeof(ValidationFilter<CompletarItemRequest>))]
        public async Task<IActionResult> CompletarItem([FromBody] CompletarItemRequest request)
        {
            try
            {
                await _executor.ExecuteAsync(request);
                return OkResponse(true, ApiMessage.OperationSuccess);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }        
    }
}
