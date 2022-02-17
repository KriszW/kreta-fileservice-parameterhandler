using Kreta.FileService.ParameterHandler.Library.Handlers.Abstractions;
using Kreta.FileService.ParameterHandler.Library.Handlers.Entities;
using System.IO;
using System.Threading.Tasks;

namespace Kreta.FileService.ParameterHandler.Library.Handlers
{
    public class HandlerService : IHandlerService
    {
        private readonly IHandlerRepository _handlerRepository;

        public HandlerService(IHandlerRepository handlerRepository)
        {
            _handlerRepository = handlerRepository;
        }

        public async Task<HandlerResponse> HandleParametersAsync(HandlerRequest handlerRequest)
        {
            var computedImage = new MemoryStream();
            await handlerRequest.Image.CopyToAsync(computedImage);

            foreach (var parameter in handlerRequest.QueryParameters)
            {
                var command = _handlerRepository.GetCommand(parameter.Key, parameter.Value);

                var computationResponse = await command.HandleAsync(new(computedImage));

                await computationResponse.ComputedImage.CopyToAsync(computedImage);
            }

            computedImage.Position = 0;
            return new(computedImage);
        }
    }
}
