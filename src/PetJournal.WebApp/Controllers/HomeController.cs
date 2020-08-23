using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using PetJournal.WebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetJournal.WebApp.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("{controller=home}/{action}")]
    public class HomeController : Controller
    {
        public IActionResult Index(int id)
        {
            return View(new HomeViewModel { PetId = id });
        }
    }
}
