using PetJournal.Contracts;
using PetJournal.Domains.Constants;
using PetJournal.Domains.Data;
using Shared.Contracts;
using Shared.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetJournal.Services.NotificationSubscribers
{
    public class PetBreedNotificationSubscriber : DefaultNotificationSubscriber<IEvent<PetBreed>>
    {
        public override void OnChange(IEvent<PetBreed> @event)
        {
            throw new NotImplementedException();
        }

        public override async Task OnChangeAsync(IEvent<PetBreed> @event)
        {
            if (! (@event is IEntityChangedEvent<PetBreed> petTypeChangedEvent) )
                throw new NotSupportedException();

            await _cacheEntityEventHandler
                .HandleEvent(Constants.PetBreedCache, petTypeChangedEvent.EventType, @event);
        }

        public PetBreedNotificationSubscriber(ICacheEntityEventHandler cacheEntityEventHandler)
        {
            _cacheEntityEventHandler = cacheEntityEventHandler;
        }

        private readonly ICacheEntityEventHandler _cacheEntityEventHandler;
    }
}
