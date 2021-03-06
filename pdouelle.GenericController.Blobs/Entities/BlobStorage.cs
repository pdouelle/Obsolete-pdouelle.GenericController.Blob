using System;
using System.Collections.Generic;

namespace pdouelle.GenericController.Blob.Entities
{
    public class BlobStorage : IEntityBlob
    {
        public string Name { get; set; }
        public string ContainerName { get; set; }
        public Uri Uri { get; set; }
        public string ContentType { get; set; }
        public long Length { get; set; }
        public IDictionary<string, string> Metadata { get; set; }
        public Uri Origin { get; set; }
        public DateTimeOffset? LastModified { get; set; }
    }
}