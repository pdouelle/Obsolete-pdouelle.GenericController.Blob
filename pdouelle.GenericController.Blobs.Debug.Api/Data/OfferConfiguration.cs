using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pdouelle.GenericController.Blobs.Debug.Api.Models.Offers.Entities;

namespace pdouelle.GenericController.Blobs.Debug.Api.Data
{
    public class OfferConfiguration : IEntityTypeConfiguration<Offer>
    {
        public void Configure(EntityTypeBuilder<Offer> builder)
        {
            builder.HasMany(p => p.Blobs)
                .WithOne(b => b.Offer)
                .HasForeignKey(p => p.OfferId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}