using item_service.ports.dto.settings;
using item_service.ports.shared.dictionary;
using item_service.ports.shared.enums;
using Microsoft.AspNetCore.Mvc;

namespace item_service.webapi.adapters.input.controllers
{
    public class BaseController : ControllerBase
    {
        protected IActionResult OkResponse<T>(T data, ApiMessage message = ApiMessage.OperationSuccess)
            => Ok(new ApiResponse<T>(true, message.GetMessage(), data, (int)message));

        protected IActionResult OkResponse<T>(bool success, ApiMessage message, T data)
            => Ok(new ApiResponse<T>(success, message.GetMessage(), data, (int)message));
        protected IActionResult BadRequestResponse(ApiMessage message = ApiMessage.BadRequest, object? errors = null)
            => BadRequest(new ApiResponse<object>(false, message.GetMessage(), errors, (int)message));
        protected IActionResult InternalErrorResponse(Exception? ex = null)
        {
            var msg = ex?.Message ?? ApiMessage.InternalServerError.GetMessage();
            return StatusCode(500, new ApiResponse<object>(false, msg, null, (int)ApiMessage.InternalServerError));
        }
    }
}
