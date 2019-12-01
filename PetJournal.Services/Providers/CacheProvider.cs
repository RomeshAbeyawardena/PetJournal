using PetJournal.Contracts.Providers;
using Shared.Contracts.Factories;
using Shared.Contracts.Services;
using Shared.Domains;
using System;
using System.Threading.Tasks;

namespace PetJournal.Services.Providers
{
    public class CacheProvider : ICacheProvider
    {
        private readonly ICacheFactory _cacheFactory;

        public T GetOrDefault<T>(string cacheName, Action<T> value, CacheType cacheType = CacheType.DistributedCache)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetOrDefaultAsync<T>(string cacheName, Func<Task<T>> value, CacheType cacheType = CacheType.DistributedCache)
            where T: class
        {
            var cacheService =  GetCacheService(cacheType);
            var result = await cacheService.Get<T>(cacheName);

            if(result != null)
                return result;
            
            result = await value();

            return await cacheService.Set(cacheName, result);
        }

        public ICacheService GetCacheService(CacheType cacheType) => _cacheFactory.GetCacheService(cacheType);

        public CacheProvider(ICacheFactory cacheFactory)
        {
            _cacheFactory = cacheFactory;
        }
    }
}
