using System;
using System.Collections.Generic;
using System.Text;

namespace PetJournal.Domains.ViewModels
{
    public class PetClassificationViewModel
    {
        public int Id { get; set; }
        public string PetType { get; set; }
        public int PetTypeId { get; set; }
        public string ShortName { get; set; }
        public string DisplayName { get; set; }
    }
}
