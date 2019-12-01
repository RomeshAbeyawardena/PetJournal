using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace PetJournal.Domains.Data
{
    public class PetType
    {
        [Key]
        public int Id { get; set; }
    }
}
