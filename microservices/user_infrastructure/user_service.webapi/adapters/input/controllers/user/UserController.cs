using Microsoft.AspNetCore.Mvc;

namespace user_service.webapi.adapters.input.controllers.user
{
    [Route("/")]
    [ApiController]
    public class UserController : BaseController
    {
        /*
        private readonly IUserUseCase _executor;
        public UserController(IUserUseCase executor)
        {
            _executor = executor;
        }
        */
        [HttpGet("test")]
        public IActionResult Get() => Ok(new { Message = "Hola desde el Microservicio de User" });
    }
}
