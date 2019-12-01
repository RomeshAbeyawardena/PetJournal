using Microsoft.AspNetCore.Mvc;
using Shared.Contracts;
using System.Collections.Generic;

namespace PetJournal.Web.Controllers.Api
{
    [Route("{controller}/{action}", Order = 99)]
    public abstract class ControllerBase : Controller
    {
        public IEnumerable<T> GetResults<T>(IEvent<T> @event)
            where T : class
        {
            if (!@event.IsSuccessful)
                throw @event.Exception;

            return @event.Results;
        }
        public T GetResult<T>(IEvent<T> @event)
            where T : class
        {
            if (!@event.IsSuccessful)
                throw @event.Exception;

            return @event.Result;
        }
    }
}