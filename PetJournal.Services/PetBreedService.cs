using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PetJournal.Contracts;
using PetJournal.Data;
using PetJournal.Domains.Data;
using Shared.Contracts;
using Shared.Contracts.Factories;
using System.Linq;

namespace PetJournal.Services
{
    public class PetBreedService : IPetBreedService
    {
        
        public PetBreedService(IRepositoryFactory repositoryFactory)
        {
            _petBreedRepository = repositoryFactory
                .GetRepository<PetJounalDbContext, PetBreed>();
        }

        public IEnumerable<PetBreed> GetPetBreedsByPetType(IEnumerable<PetBreed> petBreeds, int petTypeId)
        {
            return petBreeds.Where(petBreed => petBreed.PetTypeId == petTypeId);
        }

        public async Task<IEnumerable<PetBreed>> GetPetBreeds()
        {
            return await _petBreedRepository.Where().ToArrayAsync();
        }

        public async Task<PetBreed> SavePetBreed(PetBreed petBreed, bool saveChanges = true)
        {
            return await _petBreedRepository.SaveChangesAsync(petBreed, saveChanges);
        }

        private readonly IRepository<PetBreed> _petBreedRepository;

    }
}