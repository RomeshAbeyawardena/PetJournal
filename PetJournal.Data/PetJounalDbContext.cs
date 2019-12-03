using Microsoft.EntityFrameworkCore;
using PetJournal.Domains.Data;
using Shared.Services;

namespace PetJournal.Data
{
    public class PetJounalDbContext : ExtendedDbContext
    {
        public PetJounalDbContext(DbContextOptions dbContextOptions) 
            : base(dbContextOptions, true)
        {
        }

        public virtual DbSet<PetType> PetTypes { get; set; }
        public virtual DbSet<PetBreed> PetBreeds { get; set; }
        public virtual DbSet<PetClassification> PetClassifications { get; set; }
    }
}
