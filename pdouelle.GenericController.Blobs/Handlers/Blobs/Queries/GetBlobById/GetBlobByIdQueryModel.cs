using System;
using douell_p.GenericRepository;

namespace pdouelle.GenericController.Blob.Handlers.Blobs.Queries.GetBlobById
{
    public class GetBlobByIdQueryModel : IEntity
    {
        public Guid Id { get; set; }
    }
}