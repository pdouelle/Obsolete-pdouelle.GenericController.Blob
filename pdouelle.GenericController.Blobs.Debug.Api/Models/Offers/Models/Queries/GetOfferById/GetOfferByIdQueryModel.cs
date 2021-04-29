using System;
using douell_p.GenericRepository;
using pdouelle.GenericController.Blob.Entities;

namespace pdouelle.GenericController.Blobs.Debug.Api.Models.Offers.Models.Queries.GetOfferById
{
    public class GetOfferByIdQueryModel : IEntity, IIncludeBlobs
    {
        public Guid Id { get; set; }
        public bool IncludeBlobs { get; set; }
    }
}