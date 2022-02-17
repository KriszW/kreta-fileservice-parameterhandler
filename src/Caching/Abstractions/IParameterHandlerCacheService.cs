using Kreta.FileService.ParameterHandler.Caching.Entities;
using System.Threading.Tasks;

namespace Kreta.FileService.ParameterHandler.Caching.Abstractions
{
    public interface IParameterHandlerCacheService
    {
        Task<CachingItem> Get(string key);

        Task Save(string key, CachingItem request);

        Task Delete(string key);
    }
}
