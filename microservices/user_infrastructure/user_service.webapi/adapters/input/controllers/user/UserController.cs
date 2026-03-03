using Microsoft.AspNetCore.Mvc;
using user_service.ports.dto.user;
using user_service.ports.shared.enums;
using user_service.webapi.adapters.input.filters;

namespace user_service.webapi.adapters.input.controllers.user
{
    /// <summary>
    /// Adaptador de entrada (Controlador API) para la gestión de usuarios.
    /// Expone los endpoints necesarios para las operaciones siguiendo principios REST.
    /// </summary>
    [Route("/")]
    [ApiController]
    public class UserController : BaseController
    {
        
        private readonly IUserUseCase _executor;
        public UserController(IUserUseCase executor)
        {
            _executor = executor;
        }

        /// <summary>
        /// Procesa el registro de un nuevo usuario.
        /// </summary>
        /// <param name="request">DTO con la información requerida para la creación.</param>
        /// <returns>Resultado de la operación con estado exitoso o error interno.</returns>
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

        /// <summary>
        /// Obtiene la lista completa de usuarios registrados.
        /// </summary>
        /// <returns>Colección de usuarios transformados a DTO de respuesta.</returns>
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

        /// <summary>
        /// Actualiza la información de un usuario existente.
        /// </summary>
        /// <param name="request">DTO con los datos actualizados del usuario.</param>
        /// <returns>Estado de la operación de actualización.</returns>
        [HttpPut("editar")]
        public async Task<IActionResult> Editar([FromBody] EditarUsuarioRequest request)
        {
            try
            {
                await _executor.ExecuteAsync(request);
                return OkResponse(true, ApiMessage.OperationSuccess);
            }
            catch (Exception ex) { return InternalErrorResponse(ex); }
        }

        /// <summary>
        /// Elimina un usuario del sistema mediante su nombre de usuario.
        /// </summary>
        /// <param name="username">Nombre de usuario único a eliminar.</param>
        /// <returns>Éxito si se eliminó, o BadRequest si ocurre un error lógico.</returns>
        [HttpDelete("eliminar/{username}")]
        public async Task<IActionResult> Eliminar(string username)
        {
            try
            {
                await _executor.ExecuteAsync(username);
                return OkResponse(true, ApiMessage.OperationSuccess);
            }
            catch (Exception ex) { return BadRequestResponse(ApiMessage.BadRequest, ex.Message); }
        }
    }
}
