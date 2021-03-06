using Kreta.FileService.ParameterHandler.Library.Exceptions;
using Kreta.FileService.ParameterHandler.Library.Handlers.Abstractions;
using System.Collections.Generic;
using System.Linq;

namespace Kreta.FileService.ParameterHandler.Library.Handlers
{
    public class HandlerRepository : IHandlerRepository
    {
        private readonly IEnumerable<IParameterHandlerCommandBase> _parameterHandlerCommands;

        public HandlerRepository(IEnumerable<IParameterHandlerCommandBase> parameterHandlerCommands)
        {
            _parameterHandlerCommands = parameterHandlerCommands;
        }

        public IParameterHandlerCommandBase GetCommand(string queryName, string queryValue)
        {
            var queryCommands = _parameterHandlerCommands.Where(command => command.QueryParameterName == queryName);

            if (queryCommands.Any() == false) throw new ParameterHandlerCommandNotFoundException($"Nincs commandhandler regisztrálva a {queryName} paraméter névhez", queryName, queryValue);

            var command = queryCommands.FirstOrDefault(m => m.QueryParameterValue == queryValue);

            return command ?? throw new ParameterHandlerCommandNotFoundException($"Nincs commandhandler regisztrálva a {queryName} paraméter névhez a {queryValue} értékhez", queryName, queryValue);
        }
    }
}
