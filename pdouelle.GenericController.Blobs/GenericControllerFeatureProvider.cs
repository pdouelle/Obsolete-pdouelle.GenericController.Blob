using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using pdouelle.GenericController.Blob.Controllers;

namespace pdouelle.GenericController.Blob
{
    public class GenericControllerFeatureProvider : IApplicationFeatureProvider<ControllerFeature>
    {
        public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
        {
            foreach (GenericTypesForController genericTypesForController in IncludedEntities
                .GetIncludedEntities())
            {
                var typeName = genericTypesForController.Entity.Name + "sController";

                if (feature.Controllers.All(t => t.Name != typeName))
                {
                    TypeInfo controllerType = typeof(GenericControllerWithBlobs<,,,,,,,,,>)
                        .MakeGenericType
                        (
                            genericTypesForController.Entity.AsType(),
                            genericTypesForController.Dto.AsType(),
                            genericTypesForController.BlobEntity.AsType(),
                            genericTypesForController.BlobDto.AsType(),
                            genericTypesForController.QueryList.AsType(),
                            genericTypesForController.QueryById.AsType(),
                            genericTypesForController.Create.AsType(),
                            genericTypesForController.Update.AsType(),
                            genericTypesForController.Patch.AsType(),
                            genericTypesForController.Delete.AsType()
                        )
                        .GetTypeInfo();

                    feature.Controllers.Add(controllerType);
                }
            }
        }
    }
}