using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kreta.FileService.ParameterHandler.Library.Handlers.Abstractions
{
    public interface IHandlerService
    {
        Task InvokeCommandAsync(IList<KeyValuePair<string, string>> queryParameters);
    }
}
