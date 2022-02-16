using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kreta.FileService.ParameterHandler.Library.Handlers.Entities
{
    public record HandlerResponse
    {
        public byte[] ComputedImageData { get; set; }

        public HandlerResponse(byte[] computedImageData)
        {
            ComputedImageData = computedImageData;
        }
    }
}
