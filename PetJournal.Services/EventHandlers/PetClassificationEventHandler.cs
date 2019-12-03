using PetJournal.Contracts;
using PetJournal.Domains.Constants;
using PetJournal.Domains.Data;
using Shared.Contracts;
using Shared.Contracts.Providers;
using Shared.Domains;
using Shared.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetJournal.Services.EventHandlers
{
    public class PetClassificationEventHandler : DefaultEventHandler<IEvent<PetClassification>>
    {
        private readonly IPetClassificationService _PetClassificationService;
        private readonly ICacheProvider _cacheProvider;
        public override async Task<IEvent<PetClassification>> Push(IEvent<PetClassification> @event)
        {
            if(!@event.IsSuccessful)
                throw @event.Exception;

            return DefaultEvent.Create(await _PetClassificationService.SavePetClassification(@event.Result));

            throw @event.Exception;
        }

        public PetClassificationEventHandler(ICacheProvider cacheProvider, IPetClassificationService PetClassificationService)
        {
            _cacheProvider = cacheProvider;
            _PetClassificationService = PetClassificationService;
            CommandSwitch.CaseWhen(Constants.GetPetClassifications, GetPetClassifications);
        }

        private async Task<IEvent<PetClassification>> GetPetClassifications(ICommand command)
        {
            if(!command.Parameters.TryGetValue(Constants.PetTypeBreedParameter, out var petTypeParameter))
                throw new ArgumentException(nameof(petTypeParameter));

            var PetClassifications = await _cacheProvider.GetOrDefaultAsync(Constants.PetClassificationCache, async() => await _PetClassificationService.GetPetClassifications());

            if(petTypeParameter is PetType petType)
                return DefaultEvent.Create(results: _PetClassificationService.GetPetClassificationsByPetType(PetClassifications, petType.Id));

            if(petTypeParameter is int petTypeId)
                return DefaultEvent.Create(results: _PetClassificationService.GetPetClassificationsByPetType(PetClassifications, petTypeId));

            throw new NotSupportedException($"Expected {Constants.PetTypeBreedParameter} parameter to be of type {nameof(PetClassification)} or {nameof(Int32)}");
        }
    }
}
