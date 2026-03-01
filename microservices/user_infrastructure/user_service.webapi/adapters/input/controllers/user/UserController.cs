using Microsoft.AspNetCore.Mvc;
using user_service.ports.dto.user;
using user_service.ports.shared.enums;
using user_service.webapi.adapters.input.filters;

namespace user_service.webapi.adapters.input.controllers.user
{
    [Route("/")]
    [ApiController]
    public class UserController : BaseController
    {
        
        private readonly IUserUseCase _executor;
        public UserController(IUserUseCase executor)
        {
            _executor = executor;
        }

        [HttpPost("registrar")]
        [ServiceFilter(typeof(ValidationFilter<CrearUsuarioRequest>))]
        public async Task<IActionResult> Registrar([FromBody] CrearUsuarioRequest request)
        {
            try
            {
                await _executor.ExecuteAsync(request);
                return OkResponse(true, ApiMessage.OperationSuccess);
            }
            catch (Exception ex) { return InternalErrorResponse(ex); }
        }

        [HttpGet("listar")]
        public async Task<IActionResult> Listar()
        {
            try
            {
                var usuarios = await _executor.ExecuteAsync();
                return OkResponse(usuarios, ApiMessage.OperationSuccess);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }
    }
}
