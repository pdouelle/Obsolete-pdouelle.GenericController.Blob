using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pdouelle.GenericController.Blobs.Debug.Api.Models.Blobs.Entities;
using pdouelle.GenericController.Blobs.Debug.Api.Models.Offers.Entities;

namespace pdouelle.GenericController.Blobs.Debug.Api.Data
{
    public class BlobConfiguration : IEntityTypeConfiguration<MyBlob>
    {
        public void Configure(EntityTypeBuilder<MyBlob> builder)
        {
            builder.HasOne(p => p.Offer)
                .WithMany(b => b.Blobs)
                .HasForeignKey(p => p.OfferId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}