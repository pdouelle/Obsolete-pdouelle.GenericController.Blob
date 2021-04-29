using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using pdouelle.GenericController.Blob.Factory;
using pdouelle.GenericController.Blob.Handlers.BlobStorage.Queries.GetBlobsList;

namespace pdouelle.GenericController.Blob
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddGenericControllers
            (this IServiceCollection services, params Assembly[] assemblies)
        {
            services.AddMediatR(typeof(GetBlobsListQueryHandler).Assembly);
            services.AddAutoMapper(typeof(GetBlobsListQueryHandler).Assembly);
            
            services.AddTransient<IBlobFactory, BlobFactory>();

            IncludedEntities.Assemblies = assemblies;

            services.AddMvc().ConfigureApplicationPartManager(p =>
                p.FeatureProviders.Add(new GenericControllerFeatureProvider()));

            return services;
        }
    }
}