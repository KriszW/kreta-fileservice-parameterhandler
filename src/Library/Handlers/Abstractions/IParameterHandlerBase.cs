using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kreta.FileService.ParameterHandler.Library.Handlers.Abstractions
{
    public interface IParameterHandlerBase
    {
        /// <summary>
        /// Az URL query paraméter neve pl: ?type=Normal -> type
        /// </summary>
        public string QueryParameterName { get; }
    }
}
