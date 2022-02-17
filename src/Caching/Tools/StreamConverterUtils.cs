using System.IO;
using System.Threading.Tasks;

namespace Kreta.FileService.ParameterHandler.Caching.Tools
{
    public static class StreamConverterUtils
    {
        public static async Task<byte[]> ToArrayAsync(this Stream stream)
        {
            var output = new MemoryStream();
            stream.Position = 0;
            await stream.CopyToAsync(output);

            return output.ToArray();
        }
    }
}
