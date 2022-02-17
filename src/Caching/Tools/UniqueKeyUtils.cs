using Microsoft.AspNetCore.Http;

namespace Kreta.FileService.ParameterHandler.Caching.Tools
{
    public static class UniqueKeyUtils
    {
        public static string CreateUniqueKeyFromHttpRequest(HttpRequest httpRequest) => $"{httpRequest.Method}_{httpRequest.Path}{httpRequest.QueryString.Value}";
    }
}
