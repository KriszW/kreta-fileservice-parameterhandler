using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await Task.CompletedTask;

            return Ok();
        }
    }
}
