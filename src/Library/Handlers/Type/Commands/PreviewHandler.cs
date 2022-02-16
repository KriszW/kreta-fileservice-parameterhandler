using Kreta.FileService.ParameterHandler.Library.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kreta.FileService.ParameterHandler.Library.Handlers.Type.Commands
{
    public class PreviewHandler : TypeParameterHandlerBase, IParameterHandlerCommand<PreviewHandler.Response>
    {
        public string QueryParameterValue => throw new NotImplementedException();

        public Task<Response> HandleAsync()
        {
            throw new NotImplementedException();
        }

        public record Response();
    }
}
