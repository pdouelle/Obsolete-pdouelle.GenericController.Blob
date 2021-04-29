using Microsoft.EntityFrameworkCore;
using pdouelle.GenericController.Blobs.Debug.Api.Models.Blobs.Entities;
using pdouelle.GenericController.Blobs.Debug.Api.Models.Offers.Entities;

namespace pdouelle.GenericController.Blobs.Debug.Api.Data
{
    public class DatabaseService : DbContext
    {
        public DatabaseService(DbContextOptions<DatabaseService> options) : base(options)
        {
        }

        public DbSet<Offer> Offers { get; set; }
        public DbSet<MyBlob> Blobs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OfferConfiguration());
            modelBuilder.ApplyConfiguration(new BlobConfiguration());
        }
    }
}