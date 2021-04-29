using System.Collections.Generic;

namespace pdouelle.GenericController.Blob.Entities
{
    public interface IEntityBlobs<TBlob>
    {
        public ICollection<TBlob> Blobs { get; set; }
    }
}