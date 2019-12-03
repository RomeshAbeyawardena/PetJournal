using PetJournal.Contracts;
using Shared.Contracts;
using Shared.Contracts.Providers;
using Shared.Domains.Enumerations;
using Shared.Library.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetJournal.Services
{
    public class CacheEntityEventHandler : ICacheEntityEventHandler
    {
        private readonly ICacheProvider _cacheProvider;

        public async Task HandleEvent<T>(string cacheKeyName, EntityEventType entityEventType, IEvent<T> @event)
            where T: class
        {
            var cacheService = _cacheProvider.GetCacheService();

            if (entityEventType == EntityEventType.Added)
                await cacheService.Append(cacheKeyName, @event.Result);

            if(entityEventType == EntityEventType.Removed)
                await cacheService.Remove(cacheKeyName, @event.Result);
        }

        public CacheEntityEventHandler(ICacheProvider cacheProvider)
        {
            _cacheProvider = cacheProvider;
        }
    }
}
