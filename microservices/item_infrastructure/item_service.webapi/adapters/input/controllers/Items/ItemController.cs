using Microsoft.AspNetCore.Mvc;

namespace item_service.webapi.adapters.input.controllers.Items
{
    [Route("/")]
    [ApiController]
    public class ItemController : BaseController
    {
        /*
        private readonly IItemUseCase _executor;
        public ItemController(IItemUseCase executor)
        {
            _executor = executor;
        }
        */
        [HttpGet("test")]
        public IActionResult Get() => Ok(new { Message = "Hola desde el Microservicio de Item" });
    }
}
