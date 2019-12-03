using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Shared.Services.Attributes;

namespace PetJournal.Domains.ViewModels
{
    [OptionalRequired(1, nameof(PetType), nameof(PetTypeId))]
    public class PetBreedViewModel
    {
        public int Id { get; set; }
        public int PetTypeId { get;set; }
        public string PetType {get; set; }

        [Required]
        public string ShortName { get; set; }
        public string DisplayName { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Modified { get; set; }
    }
}
