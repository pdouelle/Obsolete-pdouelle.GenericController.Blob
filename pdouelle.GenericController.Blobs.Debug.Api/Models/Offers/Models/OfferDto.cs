using System;
using pdouelle.Entity;
using pdouelle.GenericController.Blobs.Debug.Api.Models.Blobs.Models;

namespace pdouelle.GenericController.Blobs.Debug.Api.Models.Offers.Models
{
    public class OfferDto : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public BlobDto Blob { get; set; }
    }
}