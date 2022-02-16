using Kreta.FileService.ParameterHandler.Library.Handlers.Abstractions;
using Kreta.FileService.ParameterHandler.Library.Handlers.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IHandlerService _handlerService;

        public TestController(IHandlerService handlerService)
        {
            _handlerService = handlerService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string type)
        {
            var queryParameters = HttpContext.Request.Query.Select(m => new KeyValuePair<string, string>(m.Key, m.Value.FirstOrDefault()!)).ToList();

            return Ok(await _handlerService.HandleParametersAsync(new HandlerRequest(new byte[] { 0, 0 }, queryParameters)));
        }
    }
}
