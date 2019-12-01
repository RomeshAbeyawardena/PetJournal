﻿using System.Web.Mvc;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;
using Umbraco.Web;
namespace PetJournal.Cms.Controllers
{
    public class DashboardPetController : RenderMvcController
    {
        public ActionResult Index(ContentModel contentModel, string petName)
        {
            contentModel.Content.Value(nameof(petName), defaultValue: petName);

            return base.Index(contentModel);
        }
    }
}