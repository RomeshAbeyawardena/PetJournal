﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace PetJournal.Cms.Models
{
    public partial class DashboardPet : PublishedContentModel
    {
        public DashboardPet(IPublishedContent publishedContent, string petName)
            : base(publishedContent)
        {
            this.Value("petName", defaultValue: petName);
        }
    }
}