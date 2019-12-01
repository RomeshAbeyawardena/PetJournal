using PetJournal.Contracts;
using PetJournal.Contracts.Providers;
using PetJournal.Domains.Constants;
using PetJournal.Domains.Data;
using Shared.Contracts;
using Shared.Domains;
using Shared.Services;
using System;
using System.Threading.Tasks;

namespace PetJournal.Services.EventHandlers
{
    public class PetBreedEventHandler : DefaultEventHandler<IEvent<PetBreed>>
    {
        private readonly IPetBreedService _petBreedService;
        private readonly ICacheProvider _cacheProvider;
        public override Task<IEvent<PetBreed>> Push(IEvent<PetBreed> @event)
        {
            throw new NotImplementedException();
        }

        public PetBreedEventHandler(ICacheProvider cacheProvider, IPetBreedService petBreedService)
        {
            _cacheProvider = cacheProvider;
            _petBreedService = petBreedService;
            CommandSwitch.CaseWhen(Constants.GetPetBreeds, GetPetBreeds);
        }

        private async Task<IEvent<PetBreed>> GetPetBreeds(ICommand command)
        {
            if(!command.Parameters.TryGetValue(Constants.PetTypeBreedParameter, out var petTypeParameter))
                throw new ArgumentException(nameof(petTypeParameter));

            var petBreeds = await _cacheProvider.GetOrDefaultAsync(Constants.PetBreedCache, async() => await _petBreedService.GetPetBreeds());

            if(petTypeParameter is PetType petType)
                return DefaultEvent.Create(results: _petBreedService.GetPetBreedsByPetType(petBreeds, petType.Id));

            if(petTypeParameter is int petTypeId)
                return DefaultEvent.Create(results: _petBreedService.GetPetBreedsByPetType(petBreeds, petTypeId));

            throw new NotSupportedException($"Expected {Constants.PetTypeBreedParameter} parameter to be of type {nameof(PetBreed)} or {nameof(Int32)}");
        }
    }
}
