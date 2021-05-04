using System;
using System.Collections.Generic;
using pdouelle.Entity;
using pdouelle.GenericController.Blob.Entities;

namespace pdouelle.GenericController.Blobs.Debug.Api.Models.Blobs.Models
{
    public class BlobDto : IEntity, IEntityBlob

    {
        public Guid Id { get; set; }
        public string ContainerName { get; set; }
        public string Origin { get; set; }
        public string Name { get; set; }
        public Uri Uri { get; set; }
        public string ContentType { get; set; }
        public long Length { get; set; }
        public IDictionary<string, string> Metadata { get; set; }
        public DateTimeOffset? LastModified { get; set; }
    }
}