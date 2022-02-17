using Kreta.FileService.ParameterHandler.Library.Handlers.Entities;
using System.Threading.Tasks;

namespace Kreta.FileService.ParameterHandler.Library.Handlers.Abstractions
{
    public interface IParameterHandlerCommandBase : IParameterHandlerBase
    {
        /// <summary>
        /// Az URL query paraméter értéke pl: ?type=Normal -> normal
        /// </summary>
        public string QueryParameterValue { get; }

        Task<CommandResponse> HandleAsync(CommandRequest request);
    }
}
