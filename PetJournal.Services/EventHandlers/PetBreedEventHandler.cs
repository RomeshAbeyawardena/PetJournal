using PetJournal.Domains.Data;
using Shared.Contracts;
using Shared.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetJournal.Services.EventHandlers
{
    public class PetBreedEventHandler : DefaultEventHandler<IEvent<PetType>>
    {
        public override Task<IEvent<PetType>> Push(IEvent<PetType> @event)
        {
            throw new NotImplementedException();
        }

        public PetBreedEventHandler()
        {

        }
    }
}
