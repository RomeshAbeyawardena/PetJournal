using System.Collections.Generic;
using System.Threading.Tasks;
using PetJournal.Contracts;
using PetJournal.Domains.Data;

namespace PetJournal.Services
{
    public class PetBreedService : IPetBreedService
    {
        public Task<IEnumerable<PetBreed>> GetPetBreedsByPetType(int petTypeId)
        {
            throw new System.NotImplementedException();
        }
    }
}