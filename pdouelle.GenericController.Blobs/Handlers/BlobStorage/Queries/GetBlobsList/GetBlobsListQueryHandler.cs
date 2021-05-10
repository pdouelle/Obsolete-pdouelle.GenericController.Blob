using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using AutoMapper;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using MediatR;
using pdouelle.GenericController.Blob.Models.BlobsStorage.Models.Queries.GetBlobsList;

namespace pdouelle.GenericController.Blob.Handlers.BlobStorage.Queries.GetBlobsList
{
    public class GetBlobsListQueryHandler
        : IRequestHandler<GetBlobsListQueryModel, IEnumerable<Entities.BlobStorage>>
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly IMapper _mapper;

        public GetBlobsListQueryHandler(BlobServiceClient blobServiceClient, IMapper mapper)
        {
            _blobServiceClient = blobServiceClient;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Entities.BlobStorage>> Handle
            (GetBlobsListQueryModel request, CancellationToken cancellationToken)
        {
            BlobContainerClient containerClient =
                _blobServiceClient.GetBlobContainerClient(request.ContainerName.ToLower());
            await containerClient.CreateIfNotExistsAsync(PublicAccessType.Blob, cancellationToken: cancellationToken);

            var blobsFromStorage = new List<Entities.BlobStorage>();

            await foreach (BlobItem blob in containerClient.GetBlobsAsync
                (BlobTraits.All, prefix: request.Prefix, cancellationToken: cancellationToken))
            {
                BlobClient blobClient = containerClient.GetBlobClient(HttpUtility.UrlDecode(blob.Name));

                var blobFromStorage = _mapper.Map<Entities.BlobStorage>(blob);

                blobFromStorage.Uri = new Uri(HttpUtility.UrlDecode(blobClient.Uri.AbsoluteUri));

                if (blob.Properties?.CopySource?.AbsoluteUri != null)
                    blobFromStorage.Origin = new Uri(HttpUtility.UrlDecode(blob.Properties.CopySource.AbsoluteUri));

                blobsFromStorage.Add(blobFromStorage);
            }

            return blobsFromStorage;
        }
    }
}