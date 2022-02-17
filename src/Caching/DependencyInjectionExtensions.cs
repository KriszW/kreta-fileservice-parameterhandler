using Kreta.FileService.ParameterHandler.Caching.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Kreta.FileService.ParameterHandler.Caching
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddQueryParameterHandlerCaching(this IServiceCollection services)
        {
            return services.AddSingleton<IParameterHandlerCacheService, InMemoryCacheService>();
        }
    }
}
