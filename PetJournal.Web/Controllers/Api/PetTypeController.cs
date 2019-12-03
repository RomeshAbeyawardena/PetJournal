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
using System.Threading;
using System.Threading.Tasks;

namespace PetJournal.Web.Controllers.Api
{
    public class PetTypeController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> Get([FromQuery]int? petTypeId, [FromQuery]string petType)
        {
            try{
                var parameterValue = petTypeId.HasValue ? petTypeId.Value : (object)petType;

                var foundPetType = GetResults(await _mediator.Send<PetType>(Constants.GetPetType, dictionary => { 
                    dictionary
                    .Add(Constants.PetTypeParameter, parameterValue); 
                }));

                return Ok(foundPetType);

            }
            catch(ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Save([FromForm] PetTypeViewModel petTypeViewModel)
        {
            bool isNew = petTypeViewModel.Id == 0;

            var petType = Map<PetTypeViewModel, PetType>(petTypeViewModel);

            return await _semaphore.AsLockAsync(async() => {
                
                var existingPetTypeEventResult = await _mediator.Send<PetType>(Constants.GetPetType, dictionary => 
                    dictionary.Add(Constants.PetTypeParameter, petType.ShortName));

                var existingPetType = GetResult(existingPetTypeEventResult);

                if(existingPetType != null)
                    throw new ArgumentException("Pet type of already exists", nameof(petType.ShortName));
                
                var savePetTypeEvent = await _mediator.Push(petType);

                if(savePetTypeEvent.IsSuccessful)
                    await _mediator
                    .NotifyAsync(isNew 
                        ? EntityEventType.Added 
                        : EntityEventType.Updated, savePetTypeEvent.Result);

                return Ok(petType);
            });
        }

        public PetTypeController(IMediator mediator, SemaphoreSlim semaphore)
        {
            _mediator = mediator;
            _semaphore = semaphore;
        }
        
        private readonly SemaphoreSlim _semaphore;
        private readonly IMediator _mediator;
    }
}