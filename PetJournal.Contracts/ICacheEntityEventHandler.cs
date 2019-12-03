using Shared.Contracts;
using Shared.Domains.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetJournal.Contracts
{
    public interface ICacheEntityEventHandler
    {
        Task HandleEvent<T>(string cacheKeyName, EntityEventType entityEventType, IEvent<T> @event)
            where T: class;
    }
}
