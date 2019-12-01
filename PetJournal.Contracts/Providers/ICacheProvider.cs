using Shared.Domains;
using System;
using System.Threading.Tasks;

namespace PetJournal.Contracts.Providers
{
    public interface ICacheProvider
    {
        T GetOrDefault<T>(string cacheName, Action<T> value, CacheType cacheType = CacheType.DistributedCache);
        Task<T> GetOrDefaultAsync<T>(string cacheName, Func<Task<T>> value, CacheType cacheType = CacheType.DistributedCache)
            where T: class;
    }
}
