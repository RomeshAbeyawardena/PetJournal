using PetJournal.Domains.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetJournal.Contracts
{
    public interface IPetBreedService
    {
        Task<IEnumerable<PetBreed>> GetPetBreedsByPetType(int petTypeId);
    }
}
