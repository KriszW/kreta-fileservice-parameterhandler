using Kreta.FileService.ParameterHandler.Library.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kreta.FileService.ParameterHandler.Library.Handlers.Type
{
    public class TypeParameterHandlerBase : IParameterHandlerBase
    {
        public string QueryParameterName => "type";
    }
}
