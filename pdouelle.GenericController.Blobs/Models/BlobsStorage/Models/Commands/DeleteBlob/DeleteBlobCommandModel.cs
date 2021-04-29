using MediatR;

namespace pdouelle.GenericController.Blob.Models.BlobsStorage.Models.Commands.DeleteBlob
{
    public class DeleteBlobCommandModel : IRequest<bool>
    {
        public string ContainerName { get; set; }
        public string Name { get; set; }
    }
}