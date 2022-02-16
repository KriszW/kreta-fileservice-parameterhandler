using Kreta.FileService.ParameterHandler.Library.Handlers.Abstractions;
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

        public async Task InvokeCommandAsync(IList<KeyValuePair<string, string>> queryParameters)
        {
            foreach (var parameter in queryParameters)
            {
                var command = _handlerRepository.GetCommand(parameter.Key, parameter.Value);

                await command.HandleAsync();
            }
        }
    }
}
