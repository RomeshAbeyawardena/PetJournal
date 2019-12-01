using System.Collections.Generic;
using System.Threading.Tasks;
using PetJournal.Contracts;
using PetJournal.Domains.Data;
using Shared.Contracts;
using Shared.Contracts.Factories;
using PetJournal.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace PetJournal.Services
{
    public class PetTypeService : IPetTypeService
    {
        public PetType GetPetTypeById(IEnumerable<PetType> petTypes, int petTypeId)
        {
            return petTypes.SingleOrDefault(petType => petType.Id == petTypeId);
        }

        public async Task<IEnumerable<PetType>> GetPetTypes()
        {
            return await _petTypeRepository.Where().ToArrayAsync();
        }

        public PetType GetTypeByName(IEnumerable<PetType> petTypes, string petTypeName)
        {
            return petTypes.SingleOrDefault(petType => petType.ShortName == petTypeName);
        }

        public Task<PetType> SavePetType(PetType result)
        {
            throw new System.NotImplementedException();
        }

        public PetTypeService(IRepositoryFactory repositoryFactory)
        {
            _petTypeRepository = repositoryFactory
                .GetRepository<PetJounalDbContext, PetType>();
        }

        private readonly IRepository<PetType> _petTypeRepository;
    }
}