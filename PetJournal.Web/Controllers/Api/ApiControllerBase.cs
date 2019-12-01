using Microsoft.AspNetCore.Mvc;
using Shared.Contracts;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
namespace PetJournal.Web.Controllers.Api
{
    [Route("api/{controller}/{action}", Order = 99)]
    public abstract class ApiControllerBase : ControllerBase
    {

    }
}