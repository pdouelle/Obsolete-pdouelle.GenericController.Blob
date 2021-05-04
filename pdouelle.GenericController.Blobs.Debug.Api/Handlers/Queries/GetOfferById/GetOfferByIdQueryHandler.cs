using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using pdouelle.GenericController.Blobs.Debug.Api.Models.Offers.Entities;
using pdouelle.GenericController.Blobs.Debug.Api.Models.Offers.Models.Queries.GetOfferById;
using pdouelle.GenericMediatR.Handlers.Generics.Queries.IdQuery;
using pdouelle.GenericMediatR.Models.Generics.Models.Queries.IdQuery;
using pdouelle.GenericRepository;

namespace pdouelle.GenericController.Blobs.Debug.Api.Handlers.Queries.GetOfferById
{
    public class GetOfferByIdQueryHandler : IdQueryHandler<Offer, GetOfferByIdQueryModel>
    {
        public GetOfferByIdQueryHandler(IRepository<Offer> repository) : base(repository)
        {
            
        }

        public override async Task<Offer> Handle(IdQueryModel<Offer, GetOfferByIdQueryModel> query, CancellationToken cancellationToken)
        {
            Func<IQueryable<Offer>, IIncludableQueryable<Offer, object>> include = null;

            if (query.Request.IncludeBlobs)
                include = q => q.Include(src => src.Blobs);
            
            IQueryable<Offer> queryable = Repository.Filter(include: include);
            
            return await queryable.SingleOrDefaultAsync(x => x.Id == query.Request.Id, cancellationToken);
        }
    }
}