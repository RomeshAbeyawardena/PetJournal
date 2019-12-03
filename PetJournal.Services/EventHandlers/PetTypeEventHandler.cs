using PetJournal.Contracts;
using PetJournal.Domains.Constants;
using PetJournal.Domains.Data;
using Shared.Contracts;
using Shared.Contracts.Providers;
using Shared.Domains;
using Shared.Services;
using System;
using System.Threading.Tasks;

namespace PetJournal.Services.EventHandlers
{
    public class PetTypeEventHandler : DefaultEventHandler<IEvent<PetType>>
    {
        public override async Task<IEvent<PetType>> Push(IEvent<PetType> @event)
        {
            if(!@event.IsSuccessful)
                throw @event.Exception;

            return DefaultEvent.Create(await _petTypeService.SavePetType(@event.Result));

            throw @event.Exception;
        }

        public PetTypeEventHandler(ICacheProvider cacheProvider, IPetTypeService petTypeService)
        {
            _cacheProvider = cacheProvider;
            _petTypeService = petTypeService;

            CommandSwitch.CaseWhen(Constants.GetPetType, GetPetType);
        }

        private async Task<IEvent<PetType>> GetPetType(ICommand command)
        {
            if(!command.Parameters.TryGetValue(Constants.PetTypeParameter, out var petType))
                throw new ArgumentException(nameof(petType));

            var petTypes = await _cacheProvider.GetOrDefaultAsync(Constants.PetTypeCache, async() => await _petTypeService.GetPetTypes());

            if(petType is int petTypeId)
                return DefaultEvent.Create(_petTypeService.GetPetTypeById(petTypes, petTypeId));

            if(petType is string petTypeName && !string.IsNullOrEmpty(petTypeName))
                return DefaultEvent.Create(_petTypeService.GetTypeByName(petTypes, petTypeName));

            return DefaultEvent.Create(results: petTypes);
        }

        private readonly ICacheProvider _cacheProvider;
        private readonly IPetTypeService _petTypeService;
    }
}
