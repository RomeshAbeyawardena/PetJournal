using Microsoft.AspNetCore.Mvc;
using PetJournal.Contracts;
using PetJournal.Domains.Constants;
using PetJournal.Domains.Data;
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
        public async Task<ActionResult> GetPetBreeds([FromQuery]int? petTypeId, [FromQuery]string petType)
        {
            try{
                var petTypes = await _mediator.Send<PetType>(Constants.GetPetType, dictionary => { 
                    dictionary
                    .Add(Constants.PetTypeParameter, petTypeId.HasValue ? petTypeId.Value : (object)petType); });

                if(!petTypes.IsSuccessful)
                    throw petTypes.Exception;

                var foundPetType = petTypes.Result;

                if(foundPetType == null)
                    throw new ArgumentException("", nameof(petTypeId));

                var petBreeds = await _mediator.Send<PetBreed>(Constants.GetPetBreed, dictionary => {
                    dictionary.Add(Constants.PetTypeBreedParameter, foundPetType.Id);
                });

                return Ok(petBreeds.Results);

            }
            catch(ArgumentException ex)
            {
                return BadRequest(ex);
            }
        }

        public PetBreedController(IMediator mediator)
        {
            _mediator = mediator;
        }

        private readonly IMediator _mediator;
    }
}