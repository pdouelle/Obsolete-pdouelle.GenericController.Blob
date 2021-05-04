using System;
using pdouelle.Entity;

namespace pdouelle.GenericController.Blob.Handlers.Blobs.Queries.GetBlobById
{
    public class GetBlobByIdQueryModel : IEntity
    {
        public Guid Id { get; set; }
    }
}