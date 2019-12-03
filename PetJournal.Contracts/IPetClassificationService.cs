using PetJournal.Domains.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetJournal.Contracts
{
    public interface IPetClassificationService
    {
        PetClassification GetPetClassificationById(IEnumerable<PetClassification> PetClassifications, int PetClassificationId);
        Task<IEnumerable<PetClassification>> GetPetClassifications();
        PetClassification GetTypeByName(IEnumerable<PetClassification> PetClassifications, string petClassificationName);
        Task<PetClassification> SavePetClassification(PetClassification result, bool saveChanges = true);
        IEnumerable<PetClassification> GetPetClassificationsByPetType(IEnumerable<PetClassification> petClassifications, int petTypeId);
    }
}
