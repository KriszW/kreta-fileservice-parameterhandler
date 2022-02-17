using Kreta.FileService.ParameterHandler.Caching.Abstractions;
using Kreta.FileService.ParameterHandler.Caching.Entities;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kreta.FileService.ParameterHandler.Caching
{
    public class InMemoryCacheService : IParameterHandlerCacheService
    {
        private readonly ConcurrentDictionary<string, CachingItem> responses = new ConcurrentDictionary<string, CachingItem>();

        public Task Delete(string key)
        {
            responses.TryRemove(key, out var response);

            return Task.CompletedTask;
        }

        public Task<CachingItem> Get(string key)
        {
            return Task.FromResult(responses.GetValueOrDefault(key));
        }

        public Task Save(string key, CachingItem request)
        {
            responses.TryAdd(key, request);

            return Task.CompletedTask;
        }
    }
}
