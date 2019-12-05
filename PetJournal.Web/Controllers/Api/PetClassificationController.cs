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
    public class PetClassificationController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public PetClassificationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> Save(PetClassificationViewModel petClassificationViewModel)
        {
            if(petClassificationViewModel == null)
                throw new ArgumentNullException(nameof(petClassificationViewModel));
            
            object petTypeParameter = petClassificationViewModel.PetTypeId;

            if(!string.IsNullOrEmpty(petClassificationViewModel.PetType))
                petTypeParameter = petClassificationViewModel.PetType;

            var petClassificationResult = await _mediator
                .Send<PetClassification>(Constants.GetPetClassifications, dictionary => dictionary
                .Add(Constants.PetClassificationParameter, petClassificationViewModel.ShortName)
                .Add(Constants.PetTypeParameter, petTypeParameter))
            .ConfigureAwait(false);

            if(GetResult(petClassificationResult) == null)
                throw new Exception("s", nameof(petClassificationViewModel.PetType));

            return Ok();
        }
    }
}