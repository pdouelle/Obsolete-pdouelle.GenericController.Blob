using System;
using MediatR;
using pdouelle.GenericController.Blob.Models.BlobsStorage.Enums;

namespace pdouelle.GenericController.Blob.Models.Blobs.Models.Commands.CreateBlob
{
    public class CreateBlobCommandModel<TEntity> : IRequest<TEntity>
    {
        public string Name { get; set; }
        public MyBlobType Type { get; set; }
        public string ContainerName { get; set; }
        public Guid EntityId { get; set; }
    }
}