using Kreta.FileService.ParameterHandler.Library.Handlers.Abstractions;
using Kreta.FileService.ParameterHandler.Library.Handlers.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var computedImage = handlerRequest.ImageData;

            foreach (var parameter in handlerRequest.QueryParameters)
            {
                var command = _handlerRepository.GetCommand(parameter.Key, parameter.Value);

                var computationResponse = await command.HandleAsync(new(computedImage));

                computedImage = computationResponse.ComputedImageData;
            }

            return new(computedImage);
        }
    }
}
