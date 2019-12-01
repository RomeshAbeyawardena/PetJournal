﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PetJournal.Domains.ViewModels
{
    public class PetBreedViewModel
    {
        public int Id { get; set; }

        [Required]
        public int PetTypeId { get;set; }

        [Required]
        public string ShortName { get; set; }
        public string DisplayName { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Modified { get; set; }
    }
}
