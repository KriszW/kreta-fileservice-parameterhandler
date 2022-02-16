using Kreta.FileService.ParameterHandler.Library.Handlers.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kreta.FileService.ParameterHandler.Library.MediatR
{
    public static class HandlerCommand
    {
        public record Request(IList<KeyValuePair<string, string>> QueryParameters) : IRequest;

        public class Handler : IRequestHandler<Request>
        {
            private readonly IHandlerService _handlerService;

            public Handler(IHandlerService handlerService)
            {
                _handlerService = handlerService;
            }

            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
            {
                await _handlerService.InvokeCommandAsync(request.QueryParameters);

                return Unit.Value;
            }
        }

        public record Response();
    }
}
