using AutoMapper;
using MediatR;
using pdouelle.GenericController.Blob.Controllers;
using pdouelle.GenericController.Blob.Factory;
using pdouelle.GenericController.Blobs.Debug.Api.Models.Blobs.Entities;
using pdouelle.GenericController.Blobs.Debug.Api.Models.Blobs.Models;
using pdouelle.GenericController.Blobs.Debug.Api.Models.Offers.Entities;
using pdouelle.GenericController.Blobs.Debug.Api.Models.Offers.Models;
using pdouelle.GenericController.Blobs.Debug.Api.Models.Offers.Models.Commands.CreateOffer;
using pdouelle.GenericController.Blobs.Debug.Api.Models.Offers.Models.Commands.DeleteOffer;
using pdouelle.GenericController.Blobs.Debug.Api.Models.Offers.Models.Commands.PatchOffer;
using pdouelle.GenericController.Blobs.Debug.Api.Models.Offers.Models.Commands.UpdateOffer;
using pdouelle.GenericController.Blobs.Debug.Api.Models.Offers.Models.Queries.GetOfferById;
using pdouelle.GenericController.Blobs.Debug.Api.Models.Offers.Models.Queries.GetOfferList;

namespace pdouelle.GenericController.Blobs.Debug.Api.Controllers
{
    public class OffersController : GenericControllerWithBlobs
        <Offer, OfferDto, MyBlob, BlobDto, GetOfferListQueryModel, GetOfferByIdQueryModel, CreateOfferCommandModel, UpdateOfferCommandModel, PatchOfferCommandModel, DeleteOfferCommandModel>
    {
        public OffersController(IMediator mediator, IBlobFactory factory, IMapper mapper)
            : base(mediator, factory, mapper)
        {
            _containerName = "test";
        }
    }
}