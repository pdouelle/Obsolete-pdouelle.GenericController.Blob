using System;
using pdouelle.GenericController.Blobs.Debug.Api.Models.Offers.Entities;

namespace pdouelle.GenericController.Blobs.Debug.Api.Models.Blobs.Entities
{
    public class MyBlob : Blob.Models.Blobs.Entities.Blob
    {
        public Guid? OfferId { get; set; }
        public virtual Offer Offer { get; set; }
    }
}