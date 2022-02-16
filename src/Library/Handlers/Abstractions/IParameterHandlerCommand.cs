using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kreta.FileService.ParameterHandler.Library.Abstractions
{
    public interface IParameterHandlerCommand : IParameterHandlerCommandBase
    {
        Task HandleAsync();
    }

    public interface IParameterHandlerCommand<TResult> : IParameterHandlerCommandBase
    {
        Task<TResult> HandleAsync();
    }

    public interface IParameterHandlerCommand<TResult, TParameter> : IParameterHandlerCommandBase
    {
        Task<TResult> HandleAsync(TParameter parameter);
    }
}
