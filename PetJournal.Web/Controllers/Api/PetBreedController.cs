using Microsoft.AspNetCore.Mvc;
using PetJournal.Domains.Constants;
using PetJournal.Domains.Data;
using PetJournal.Domains.ViewModels;
using Shared.Contracts;
using Shared.Domains.Enumerations;
using Shared.Library.Extensions;
using Shared.Services;
using Shared.Services.Extensions;
using System;
using System.Threading.Tasks;

namespace PetJournal.Web.Controllers.Api
{
    public class PetBreedController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> Get([FromQuery]int? petTypeId, [FromQuery]string petType)
        {
            try
            {
                var parameterValue = petTypeId.HasValue ? petTypeId.Value : (object)petType;
                var foundPetType = await GetPetType(parameterValue);
                var petBreeds = GetResults(await _mediator.Send<PetBreed>(Constants.GetPetBreeds, dictionary =>
                {
                    dictionary.Add(Constants.PetTypeBreedParameter, foundPetType);
                }));

                return Ok(petBreeds);

            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Save([FromForm] PetBreedViewModel petBreedViewModel)
        {
            var petTypeParameter = petBreedViewModel.PetTypeId.ValueOrDefault(petBreedViewModel.PetType);

            var petType = await GetPetType(petTypeParameter);

            var petBreed = Map<PetBreedViewModel, PetBreed>(petBreedViewModel);
            bool isNew = petBreedViewModel.Id == 0;

            petBreed.PetTypeId = petType.Id;

            var savePetBreedEvent = await _mediator.Push(petBreed);

            if(savePetBreedEvent.IsSuccessful)
                await _mediator.NotifyAsync(isNew 
                        ? EntityEventType.Added 
                        : EntityEventType.Updated, savePetBreedEvent.Result);

            return Ok(petBreed);
        }

        public PetBreedController(IMediator mediator)
        {
            _mediator = mediator;
        }

        private async Task<PetType> GetPetType(object petTypeParameter)
        {
            var foundPetType = GetResult(await _mediator.Send<PetType>(Constants.GetPetType, dictionary =>
            {
                dictionary
                .Add(Constants.PetTypeParameter, petTypeParameter);
            }));

            if (foundPetType == null)
                throw new ArgumentException($"Unable to find {nameof(PetType)} with {petTypeParameter}", nameof(petTypeParameter));
            return foundPetType;
        }

        private readonly IMediator _mediator;
    }
}