using Kreta.FileService.ParameterHandler.Caching.Abstractions;
using Kreta.FileService.ParameterHandler.Caching.Tools;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Kreta.FileService.ParameterHandler.Caching.Middleware
{
    public class ParameterHandlerCachingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IParameterHandlerCacheService _parameterHandlerCacheService;

        public ParameterHandlerCachingMiddleware(RequestDelegate next,
                                                 IParameterHandlerCacheService parameterHandlerCacheService)
        {
            _next = next;
            _parameterHandlerCacheService = parameterHandlerCacheService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var key = UniqueKeyUtils.CreateUniqueKeyFromHttpRequest(context.Request);
            var response = await _parameterHandlerCacheService.Get(key);

            if (response != default)
            {
                context.Response.StatusCode = 200;
                context.Response.ContentType = response.ContentType;

                if (response.IsFile())
                {
                    await context.Response.Body.WriteAsync(Convert.FromBase64String(response.ImageBase64Content));
                }
                else
                {
                    await context.Response.WriteAsync(response.BuildReturnData());
                }

                return;
            }

            await _next(context);
        }
    }
}
