using Microsoft.EntityFrameworkCore;
using PetJournal.Contracts;
using PetJournal.Data;
using PetJournal.Domains.Data;
using Shared.Contracts;
using Shared.Contracts.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetJournal.Services
{
    public class PetClassificationService : IPetClassificationService
    {
        public PetClassification GetPetClassificationById(IEnumerable<PetClassification> petClassifications, int petClassificationId)
        {
            return petClassifications.SingleOrDefault(petClassification => petClassification.Id == petClassificationId);
        }

        public async Task<IEnumerable<PetClassification>> GetPetClassifications()
        {
            return await _petClassificationRepository.Where()
                .ToArrayAsync().ConfigureAwait(false);
        }

        public IEnumerable<PetClassification> GetPetClassificationsByPetType(IEnumerable<PetClassification> petClassifications, int petTypeId)
        {
            return petClassifications.Where(petClassification => petClassification.PetTypeId == petTypeId);
        }

        public PetClassification GetTypeByName(IEnumerable<PetClassification> petClassifications, string petClassificationName)
        {
            return petClassifications.SingleOrDefault(petClassification => petClassification.ShortName == petClassificationName);
        }

        public async Task<PetClassification> SavePetClassification(PetClassification result, bool saveChanges = true)
        {
            return await _petClassificationRepository
                .SaveChangesAsync(result, saveChanges)
                .ConfigureAwait(false);
        }

        public PetClassificationService(IRepositoryFactory repositoryFactory)
        {
            if(repositoryFactory == null)
                throw new ArgumentNullException(nameof(repositoryFactory));

            _petClassificationRepository = repositoryFactory.GetRepository<PetJounalDbContext, PetClassification>();
        }

        private readonly IRepository<PetClassification> _petClassificationRepository;
    }
}
