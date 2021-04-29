using System.Collections.Generic;
using MediatR;

namespace pdouelle.GenericController.Blob.Models.BlobsStorage.Models.Queries.GetBlobsList
{
    public class GetBlobsListQueryModel : IRequest<IEnumerable<Entities.BlobStorage>>
    {
        public string ContainerName { get; set; }
        public string Prefix { get; set; }
    }
}