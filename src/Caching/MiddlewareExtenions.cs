using Kreta.FileService.ParameterHandler.Caching.Middleware;
using Microsoft.AspNetCore.Builder;

namespace Kreta.FileService.ParameterHandler.Caching
{
    public static class MiddlewareExtenions
    {
        public static IApplicationBuilder UseQueryParameterHandlerCaching(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ParameterHandlerCachingMiddleware>();
        }
    }
}
