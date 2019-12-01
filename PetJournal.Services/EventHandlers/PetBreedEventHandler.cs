using PetJournal.Contracts;
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

        public override Task<IEvent<PetBreed>> Push(IEvent<PetBreed> @event)
        {
            throw new NotImplementedException();
        }

        public PetBreedEventHandler(IPetBreedService petBreedService)
        {
            _petBreedService = petBreedService;

            CommandSwitch.CaseWhen(Constants.GetPetBreeds, GetPetBreeds);
        }

        private async Task<IEvent<PetBreed>> GetPetBreeds(ICommand command)
        {
            if(!command.Parameters.TryGetValue(Constants.PetTypeBreedParameter, out var petTypeParameter))
                throw new ArgumentException(nameof(petTypeParameter));

            if(petTypeParameter is PetType petType)
                return DefaultEvent.Create(results: await _petBreedService.GetPetBreedsByPetType(petType.Id));

            if(petTypeParameter is int petTypeId)
                return DefaultEvent.Create(results: await _petBreedService.GetPetBreedsByPetType(petTypeId));

            throw new NotSupportedException($"Expected {Constants.PetTypeBreedParameter} parameter to be of type {nameof(PetBreed)} or {nameof(Int32)}");
        }
    }
}
