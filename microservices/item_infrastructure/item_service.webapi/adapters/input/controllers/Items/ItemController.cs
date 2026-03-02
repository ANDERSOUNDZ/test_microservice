using item_service.ports.dto.item;
using item_service.ports.shared.enums;
using item_service.webapi.adapters.input.filters;
using Microsoft.AspNetCore.Mvc;

namespace item_service.webapi.adapters.input.controllers.Items
{
    [Route("/")]
    [ApiController]
    public class ItemController : BaseController
    {
        
        private readonly IItemUseCase _executor;
        public ItemController(IItemUseCase executor)
        {
            _executor = executor;
        }

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
