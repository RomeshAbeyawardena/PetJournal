using PetJournal.Domains.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetJournal.Contracts
{
    public interface IPetTypeService
    {
        Task<PetType> GetPetTypeById(IEnumerable<PetType> petTypes, int petTypeId);
        Task<IEnumerable<PetType>> GetPetTypes();
        Task<PetType> GetTypeByName(IEnumerable<PetType> petTypes, string petTypeName);
    }
}
