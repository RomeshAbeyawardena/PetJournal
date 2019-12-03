using Microsoft.AspNetCore.Mvc;
using Shared.Contracts;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
namespace PetJournal.Web.Controllers.Api
{
    [Route("api/{controller}/{action}", Order = 1)]
    public abstract class ApiControllerBase : ControllerBase
    {

    }
}