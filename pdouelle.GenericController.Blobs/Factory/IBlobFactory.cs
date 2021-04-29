using System.Collections.Generic;
using pdouelle.GenericController.Blob.Entities;

namespace pdouelle.GenericController.Blob.Factory
{
    public interface IBlobFactory
    {
        IEnumerable<TEntityDto> MapBlob<TEntity, TEntityDto, TBlobDto>
            (IEnumerable<TEntity> itemsToMap, IEnumerable<BlobStorage> blobs)
            where TBlobDto : IEntityBlob;

        TEntityDto MapBlob<TEntity, TEntityDto, TBlobDto>(TEntity itemToMap, IEnumerable<BlobStorage> blobs)
            where TBlobDto : IEntityBlob;
    }
}