using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Storage.Blobs;
using MediatR;
using pdouelle.GenericController.Blob.Models.BlobsStorage.Models.Commands.DeleteBlob;

namespace pdouelle.GenericController.Blob.Handlers.BlobStorage.Commands.DeleteBlobStorage
{
    public class DeleteBlobStorageCommandHandler : IRequestHandler<DeleteBlobCommandModel, bool>
    {
        private readonly BlobServiceClient _blobServiceClient;

        public DeleteBlobStorageCommandHandler(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        public async Task<bool> Handle(DeleteBlobCommandModel request, CancellationToken cancellationToken)
        {
            BlobContainerClient containerClient = _blobServiceClient.GetBlobContainerClient(request.ContainerName.ToLower());

            BlobClient blobClient = containerClient.GetBlobClient(request.Name);

            Response<bool> isDeleted = await blobClient.DeleteIfExistsAsync(cancellationToken: cancellationToken);

            return isDeleted;
        }
    }
}