using PetJournal.Contracts.Providers;
using Shared.Domains;
using System;
using System.Threading.Tasks;

namespace PetJournal.Services.Providers
{
    public class CacheProvider : ICacheProvider
    {
        public T GetOrDefault<T>(string cacheName, Action<T> value, CacheType cacheType = CacheType.DistributedCache)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetOrDefaultAsync<T>(string cacheName, Func<Task<T>> value, CacheType cacheType = CacheType.DistributedCache)
        {
            throw new NotImplementedException();
        }
    }
}
