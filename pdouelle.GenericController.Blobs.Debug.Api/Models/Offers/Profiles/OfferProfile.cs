using System.Linq;
using AutoMapper;
using pdouelle.GenericController.Blobs.Debug.Api.Models.Offers.Entities;
using pdouelle.GenericController.Blobs.Debug.Api.Models.Offers.Models;
using pdouelle.GenericController.Blobs.Debug.Api.Models.Offers.Models.Commands.CreateOffer;
using pdouelle.GenericController.Blobs.Debug.Api.Models.Offers.Models.Commands.PatchOffer;
using pdouelle.GenericController.Blobs.Debug.Api.Models.Offers.Models.Commands.UpdateOffer;

namespace pdouelle.GenericController.Blobs.Debug.Api.Models.Offers.Profiles
{
    public class OfferProfile : Profile
    {
        public OfferProfile()
        {
            CreateMap<Offer, OfferDto>()
                .ForMember(dest => dest.Blob, o => o.MapFrom(src => src.Blobs.FirstOrDefault()));
            CreateMap<CreateOfferCommandModel, Offer>();
            CreateMap<UpdateOfferCommandModel, Offer>();
            CreateMap<PatchOfferCommandModel, Offer>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}