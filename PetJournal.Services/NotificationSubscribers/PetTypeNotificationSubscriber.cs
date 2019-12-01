using PetJournal.Contracts.Providers;
using PetJournal.Domains.Constants;
using PetJournal.Domains.Data;
using Shared.Contracts;
using Shared.Library.Extensions;
using Shared.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetJournal.Services.NotificationSubscribers
{
    public class PetTypeNotificationSubscriber : DefaultNotificationSubscriber<IEvent<PetType>>
    {
        public override void OnChange(IEvent<PetType> @event)
        {
            throw new NotImplementedException();
        }

        public override async Task OnChangeAsync(IEvent<PetType> @event)
        {
            var cacheService = _cacheProvider.GetCacheService();
            if (! (@event is IEntityChangedEvent<PetType> petTypeChangedEvent) )
                throw new NotSupportedException();

            if (petTypeChangedEvent.EventType == Shared.Domains.EntityEventType.Added)
                await cacheService.Append(Constants.PetTypeCache, @event.Result);
        }

        public PetTypeNotificationSubscriber(ICacheProvider cacheProvider)
        {
            _cacheProvider = cacheProvider;
        }

        private ICacheProvider _cacheProvider;
    }
}
