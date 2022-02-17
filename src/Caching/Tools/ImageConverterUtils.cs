using System;
using System.IO;
using System.Threading.Tasks;

namespace Kreta.FileService.ParameterHandler.Caching.Tools
{
    public static class ImageConverterUtils
    {
        public static async Task<string> ConvertImageToBase64Async(Stream file)
        {
            using var ms = new MemoryStream();

            file.Position = 0;
            await file.CopyToAsync(ms);
            file.Position = 0;

            return Convert.ToBase64String(ms.ToArray());
        }
    }
}
