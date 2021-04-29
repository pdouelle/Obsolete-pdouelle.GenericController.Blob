using System;
using System.IO;
using Azure.Storage.Blobs.Models;

namespace pdouelle.GenericController.Blob
{
    public static class BlobHelper
    {
        public static string GetBlobName(Guid id, BlobType type, string blobName) =>
            Path.Combine(
                    id.ToString("N"),
                    type.ToString(),
                    Path.GetFileName(blobName))
                .Replace(
                    Path.DirectorySeparatorChar,
                    Path.AltDirectorySeparatorChar);
    }
}