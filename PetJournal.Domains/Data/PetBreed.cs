using System.ComponentModel.DataAnnotations;

namespace PetJournal.Domains.Data
{
    public class PetBreed
    {
        [Key]
        public int Id { get; set; }
        public int PetTypeId { get;set; }
        public virtual PetType PetType { get; set; }
    }
}
