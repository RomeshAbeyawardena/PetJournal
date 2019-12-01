using Microsoft.AspNetCore.Mvc;
using Shared.Contracts;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
namespace PetJournal.Web.Controllers.Api
{
    [Route("{controller}/{action}", Order = 99)]
    public abstract class ControllerBase : Controller
    {
        protected TService GetRequiredService<TService>() => HttpContext.RequestServices.GetRequiredService<TService>();

        protected IEnumerable<T> GetResults<T>(IEvent<T> @event)
            where T : class
        {
            if (!@event.IsSuccessful)
                throw @event.Exception;

            return @event.Results;
        }

        protected T GetResult<T>(IEvent<T> @event)
            where T : class
        {
            if (!@event.IsSuccessful)
                throw @event.Exception;
            
            return @event.Result;
        }

        protected TDest Map<TSource, TDest>(TSource source) {
           var mapper = GetRequiredService<IMapperProvider>();

            return mapper.Map<TSource, TDest>(source);
        }

        protected IEnumerable<TDest> Map<TSource, TDest>(IEnumerable<TSource> source) {
           var mapper = GetRequiredService<IMapperProvider>();

            return mapper.Map<TSource, TDest>(source);
        }
    }
}