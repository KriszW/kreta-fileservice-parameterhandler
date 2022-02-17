using Kreta.FileService.ParameterHandler.Library.Handlers.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Formats.Png;
using System.IO;
using Kreta.FileService.ParameterHandler.Library.Handlers.Abstractions;

namespace Kreta.FileService.ParameterHandler.Library.Handlers.Type.Commands
{
    public class PreviewHandler : TypeParameterHandlerBase, IParameterHandlerCommandBase
    {
        public string QueryParameterValue => "preview";

        public async Task<CommandResponse> HandleAsync(CommandRequest request)
        {
            var output = new MemoryStream();

            request.Image.Position = 0;
            var img = Image.Load(request.Image);

            img.Mutate(x => x.Resize(300, 0));

            img.Save(output, new PngEncoder());

            await request.Image.CopyToAsync(output);
            output.Position = 0;
            return new(output);
        }
    }
}
