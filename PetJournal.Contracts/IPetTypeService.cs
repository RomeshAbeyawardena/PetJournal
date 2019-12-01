using PetJournal.Domains.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetJournal.Contracts
{
    public interface IPetTypeService
    {
        PetType GetPetTypeById(IEnumerable<PetType> petTypes, int petTypeId);
        Task<IEnumerable<PetType>> GetPetTypes();
        PetType GetTypeByName(IEnumerable<PetType> petTypes, string petTypeName);
        Task<PetType> SavePetType(PetType result, bool saveChanges = true);
    }
}
