using pdouelle.GenericController.Blob.Entities;

namespace pdouelle.GenericController.Blobs.Debug.Api.Models.Offers.Models.Queries.GetOfferList
{
    public class GetOfferListQueryModel : IIncludeBlobs
    {
        public bool IncludeBlobs { get; set; }
    }
}