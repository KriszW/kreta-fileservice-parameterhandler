using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kreta.FileService.ParameterHandler.Library.Handlers.Entities
{
    public record HandlerRequest(Stream Image, IList<KeyValuePair<string, string>> QueryParameters);
}
