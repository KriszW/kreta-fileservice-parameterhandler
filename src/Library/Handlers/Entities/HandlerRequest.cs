using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kreta.FileService.ParameterHandler.Library.Handlers.Entities
{
    public class HandlerRequest
    {
        public HandlerRequest(byte[] imageData,
                              IList<KeyValuePair<string, string>> queryParameters)
        {
            ImageData = imageData;
            QueryParameters = queryParameters;
        }

        public byte[] ImageData { get; init; }
        public IList<KeyValuePair<string, string>> QueryParameters { get; init; }
    }
}
