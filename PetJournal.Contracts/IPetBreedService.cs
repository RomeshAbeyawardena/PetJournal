using PetJournal.Domains.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetJournal.Contracts
{
    public interface IPetBreedService
    {
        Task<IEnumerable<PetBreed>> GetPetBreedsByPetType(int petTypeId);
    }
}
