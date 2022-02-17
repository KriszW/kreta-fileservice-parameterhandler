using Kreta.FileService.ParameterHandler.Caching.Abstractions;
using Kreta.FileService.ParameterHandler.Caching.Entities;
using Kreta.FileService.ParameterHandler.Caching.Tools;
using Kreta.FileService.ParameterHandler.Library.Handlers.Abstractions;
using Kreta.FileService.ParameterHandler.Library.Handlers.Entities;
using Microsoft.AspNetCore.Mvc;

namespace TestUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IHandlerService _handlerService;
        private readonly IParameterHandlerCacheService _parameterHandlerCacheService;

        public TestController(IHandlerService handlerService,
                              IParameterHandlerCacheService parameterHandlerCacheService)
        {
            _handlerService = handlerService;
            _parameterHandlerCacheService = parameterHandlerCacheService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string type = "preview")
        {
            Console.WriteLine($"{CreateUniqueURL()} accessed from controller");

            var queryParameters = Request.Query.Select(m => new KeyValuePair<string, string>(m.Key, m.Value.FirstOrDefault()!)).ToList();

            using var image = System.IO.File.OpenRead("TestData/test.jpg");

            var response = await _handlerService.HandleParametersAsync(new HandlerRequest(image, queryParameters));
            await _parameterHandlerCacheService.Save(CreateUniqueURL(), new CachingItem(await ImageConverterUtils.ConvertImageToBase64Async(response.ComputedImage), "image/png"));

            return File(response.ComputedImage, "image/png");
        }

        private string CreateUniqueURL()
        {
            return UniqueKeyUtils.CreateUniqueKeyFromHttpRequest(Request);
        }
    }
}
