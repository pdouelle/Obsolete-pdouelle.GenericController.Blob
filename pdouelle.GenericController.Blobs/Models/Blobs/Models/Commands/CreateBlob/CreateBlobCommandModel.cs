using System;
using System.Web;
using MediatR;
using pdouelle.GenericController.Blob.Models.BlobsStorage.Enums;

namespace pdouelle.GenericController.Blob.Models.Blobs.Models.Commands.CreateBlob
{
    public class CreateBlobCommandModel<TEntity> : IRequest<TEntity>
    {
        private string _name { get; set; }

        public string Name
        {
            get => _name;
            set => _name = HttpUtility.UrlDecode(value);
        }

        public MyBlobType Type { get; set; }
        public string ContainerName { get; set; }
        public Guid EntityId { get; set; }
    }
}