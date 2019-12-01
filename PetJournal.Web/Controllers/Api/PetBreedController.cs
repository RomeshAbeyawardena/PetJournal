using Microsoft.AspNetCore.Mvc;
using PetJournal.Domains.Constants;
using PetJournal.Domains.Data;
using PetJournal.Domains.ViewModels;
using Shared.Contracts;
using Shared.Services.Extensions;
using System;
using System.Threading.Tasks;

namespace PetJournal.Web.Controllers.Api
{
    [Route("api/{controller}/{action}", Order = 1)]
    public class PetBreedController : ControllerBase
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

                if(foundPetType == null)
                    throw new ArgumentException($"Unable to find {nameof(PetType)} with {petTypeId}", nameof(petTypeId));

                var petBreeds = GetResults(await _mediator.Send<PetBreed>(Constants.GetPetBreeds, dictionary => {
                    dictionary.Add(Constants.PetTypeBreedParameter, foundPetType);
                }));

                return Ok(petBreeds);

            }
            catch(ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Save([FromForm] PetBreedViewModel petBreedViewModel)
        {
            var petBreed = Map<PetBreedViewModel, PetBreed>(petBreedViewModel);
            return Ok(await _mediator.Push(petBreed));
        }

        public PetBreedController(IMediator mediator)
        {
            _mediator = mediator;
        }

        private readonly IMediator _mediator;
    }
}