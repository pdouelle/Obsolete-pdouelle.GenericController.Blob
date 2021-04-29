using AutoMapper;
using pdouelle.GenericController.Blob.Entities;
using pdouelle.GenericController.Blobs.Debug.Api.Models.Blobs.Entities;
using pdouelle.GenericController.Blobs.Debug.Api.Models.Blobs.Models;

namespace pdouelle.GenericController.Blobs.Debug.Api.Models.Blobs.Profiles
{
    public class BlobProfile : Profile
    {
        public BlobProfile()
        {
            CreateMap<MyBlob, BlobDto>();
            CreateMap<BlobStorage, BlobDto>();
        }
    }
}