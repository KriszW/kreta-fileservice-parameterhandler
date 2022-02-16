using Kreta.FileService.ParameterHandler.Library.Handlers.Abstractions;
using Kreta.FileService.ParameterHandler.Library.Handlers.Entities;
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
        public record Request(HandlerRequest HandlerRequest) : IRequest<Response>;

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IHandlerService _handlerService;

            public Handler(IHandlerService handlerService)
            {
                _handlerService = handlerService;
            }

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var response = await _handlerService.HandleParametersAsync(request.HandlerRequest);

                return new(response);
            }
        }

        public record Response(HandlerResponse HandlerResponse);
    }
}
