using PetJournal.Domains.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetJournal.Contracts
{
    public interface IPetBreedService
    {
        IEnumerable<PetBreed> GetPetBreedsByPetType(IEnumerable<PetBreed> petBreeds, int petTypeId);
        Task<IEnumerable<PetBreed>> GetPetBreeds();
    }
}
