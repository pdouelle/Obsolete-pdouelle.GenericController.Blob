using AutoMapper;
using Azure.Storage.Blobs.Models;

namespace pdouelle.GenericController.Blob.Profiles
{
    public class BlobProfile : Profile
    {
        public BlobProfile()
        {
            CreateMap<BlobItem, Entities.BlobStorage>()
                .ForMember(dest => dest.ContentType, o => o.MapFrom(src => src.Properties.ContentType))
                .ForMember(dest => dest.Length, o => o.MapFrom(src => src.Properties.ContentLength))
                .ForMember(dest => dest.Origin, o => o.MapFrom(src => src.Properties.CopySource.AbsoluteUri))
                .ForMember(dest => dest.LastModified, o => o.MapFrom(src => src.Properties.LastModified));
        }
    }
}