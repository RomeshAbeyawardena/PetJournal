using PetJournal.Domains.Constants;
using PetJournal.Domains.Data;
using Shared.Contracts;
using Shared.Contracts.Providers;
using Shared.Library.Extensions;
using Shared.Services;
using System;
using System.Collections.Generic;
using Shared.Domains.Enumerations;
using System.Threading.Tasks;
using PetJournal.Contracts;

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
            if (! (@event is IEntityChangedEvent<PetType> petTypeChangedEvent) )
                throw new NotSupportedException();

            await _cacheEntityEventHandler.HandleEvent(Constants.PetTypeCache, petTypeChangedEvent.EventType, @event);
        }

        public PetTypeNotificationSubscriber(ICacheEntityEventHandler cacheEntityEventHandler)
        {
            _cacheEntityEventHandler = cacheEntityEventHandler;
        }

        private readonly ICacheEntityEventHandler _cacheEntityEventHandler;
    }
}
