using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Azure.Storage.Blobs;
using douell_p.GenericRepository;
using MediatR;
using pdouelle.GenericController.Blob.Models.Blobs.Models.Commands.CreateBlob;

namespace pdouelle.GenericController.Blob.Handlers.Blobs.Commands.CreateBlob
{
    public class CreateBlobCommandHandler<TEntity> : IRequestHandler<CreateBlobCommandModel<TEntity>, TEntity> where TEntity : IEntity
    {
        protected readonly IRepository<TEntity> Repository;
        private readonly IMapper _mapper;
        
        public CreateBlobCommandHandler(BlobServiceClient blobServiceClient, IRepository<TEntity> repository, IMapper mapper)
        {
            Repository = repository;
            _mapper = mapper;
        }

        public async Task<TEntity> Handle(CreateBlobCommandModel<TEntity> request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<TEntity>(request);

            Repository.Create(entity);

            return entity;
        }
    }
}