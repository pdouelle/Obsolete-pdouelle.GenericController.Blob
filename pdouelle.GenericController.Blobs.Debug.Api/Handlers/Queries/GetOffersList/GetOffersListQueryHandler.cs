using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using pdouelle.GenericController.Blobs.Debug.Api.Models.Offers.Entities;
using pdouelle.GenericController.Blobs.Debug.Api.Models.Offers.Models.Queries.GetOfferList;
using pdouelle.GenericMediatR.Handlers.Generics.Queries.ListQuery;
using pdouelle.GenericMediatR.Models.Generics.Models.Queries.ListQuery;
using pdouelle.GenericRepository;

namespace pdouelle.GenericController.Blobs.Debug.Api.Handlers.Queries.GetOffersList
{
    public class GetOffersListQueryHandler : ListQueryHandler<Offer, GetOfferListQueryModel>
    {
        public GetOffersListQueryHandler(IRepository<Offer> repository) : base(repository)
        {
        }

        public override async Task<IEnumerable<Offer>> Handle
            (ListQueryModel<Offer, GetOfferListQueryModel> listQuery, CancellationToken cancellationToken)
        {
            Func<IQueryable<Offer>, IIncludableQueryable<Offer, object>> include = null;

            if (listQuery.Request.IncludeBlobs)
                include = queryable => queryable.Include(src => src.Blobs);
            
            IQueryable<Offer> query = Repository.Filter(include: include);
            
            return await query.ToListAsync(cancellationToken);
        }
    }
}