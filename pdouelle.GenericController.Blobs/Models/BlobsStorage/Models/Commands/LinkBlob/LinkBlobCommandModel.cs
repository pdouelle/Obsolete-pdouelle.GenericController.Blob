using System.ComponentModel.DataAnnotations;
using pdouelle.GenericController.Blob.Models.BlobsStorage.Enums;

namespace pdouelle.GenericController.Blob.Models.BlobsStorage.Models.Commands.LinkBlob
{
    public class LinkBlobCommandModel
    {
        [Required] public MyBlobType? Type { get; set; }  
    }
}