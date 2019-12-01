using Microsoft.AspNetCore.Mvc;
using PetJournal.Domains.Constants;
using PetJournal.Domains.Data;
using PetJournal.Domains.ViewModels;
using Shared.Contracts;
using Shared.Domains;
using Shared.Services;
using Shared.Services.Extensions;
using System;
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

                var foundPetType = GetResult(await _mediator.Send<PetType>(Constants.GetPetType, dictionary => { 
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

            var savePetTypeEvent = await _mediator.Push(petType);

            if(savePetTypeEvent.IsSuccessful)
                await _mediator
                    .NotifyAsync(DefaultEntityChangedEvent.Create(savePetTypeEvent.Result, 
                        entityEventType: isNew 
                        ? EntityEventType.Added 
                        : EntityEventType.Updated));

            return Ok(petType);
        }

        public PetTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        private readonly IMediator _mediator;
    }
}