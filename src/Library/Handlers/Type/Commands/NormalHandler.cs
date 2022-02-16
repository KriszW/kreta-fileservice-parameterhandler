using Kreta.FileService.ParameterHandler.Library.Abstractions;
using Kreta.FileService.ParameterHandler.Library.Handlers.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kreta.FileService.ParameterHandler.Library.Handlers.Type.Commands
{
    public class NormalHandler : TypeParameterHandlerBase, IParameterHandlerCommandBase
    {
        public string QueryParameterValue => "normal";

        public Task<CommandResponse> HandleAsync(CommandRequest request)
        {
            request.ImageData[0] = 1;
            return Task.FromResult(new CommandResponse(request.ImageData));
        }
    }
}
