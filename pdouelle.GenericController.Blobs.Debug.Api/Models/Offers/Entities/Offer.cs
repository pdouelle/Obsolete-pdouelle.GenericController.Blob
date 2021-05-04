using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using pdouelle.Entity;
using pdouelle.GenericController.Blob.Entities;
using pdouelle.GenericController.Blobs.Debug.Api.Models.Blobs.Entities;
using pdouelle.GenericController.Blobs.Debug.Api.Models.Offers.Models.Commands.CreateOffer;
using pdouelle.GenericController.Blobs.Debug.Api.Models.Offers.Models.Commands.DeleteOffer;
using pdouelle.GenericController.Blobs.Debug.Api.Models.Offers.Models.Commands.PatchOffer;
using pdouelle.GenericController.Blobs.Debug.Api.Models.Offers.Models.Commands.UpdateOffer;
using pdouelle.GenericMediatR;

namespace pdouelle.GenericController.Blobs.Debug.Api.Models.Offers.Entities
{
    [GenericMediatREntity(
        Create = typeof(CreateOfferCommandModel),
        Update = typeof(UpdateOfferCommandModel),
        Patch = typeof(PatchOfferCommandModel),
        Delete = typeof(DeleteOfferCommandModel)
    )]
    public class Offer : IEntity, IEntityBlobs<MyBlob>
    {
        [Key] public Guid Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<MyBlob> Blobs { get; set; }
    }
}