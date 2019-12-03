using MessagePack;
using System;
using AnnotationKey = System.ComponentModel.DataAnnotations.KeyAttribute;
namespace PetJournal.Domains.Data
{
    [MessagePackObject(true)]
    public class PetClassification
    {
        [AnnotationKey]
        public int Id { get; set; }
        public int PetTypeId { get; set; }
        public string ShortName { get; set; }
        public string DisplayName { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Modified { get; set; }

        public virtual PetType PetType { get; set; }
    }
}
