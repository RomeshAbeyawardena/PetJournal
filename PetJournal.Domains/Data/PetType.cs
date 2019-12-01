using System;
using System.ComponentModel.DataAnnotations;

namespace PetJournal.Domains.Data
{
    public class PetType
    {
        [Key]
        public int Id { get; set; }
        public string ShortName { get; set; }
        public string DisplayName { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Modified { get; set; }

    }
}
