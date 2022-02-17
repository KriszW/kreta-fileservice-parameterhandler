using Kreta.FileService.ParameterHandler.Caching.Abstractions;

namespace Kreta.FileService.ParameterHandler.Caching.Entities
{
    public record CachingItem(string ImageBase64Content, string ContentType)
    {
        public string BuildReturnData() => ImageBase64Content;

        // Eddig csak fileok vannak cachelve
        // Ha nem akkor a ContentType alapján tudjuk eldönteni,
        // És akkor kell implementálni csak ezt a functiont
        public bool IsFile() => true;
    }
}
