using Microsoft.AspNetCore.Mvc;

namespace PetJournal.Web.Controllers.Api
{
    [Route("{controller}/{action}", Order = 99)]
    public abstract class ControllerBase : Controller
    {

    }
}