using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace pdouelle.GenericController.Blob
{
    public static class IncludedEntities
    {
        public static Assembly[] Assemblies { get; set; }

        public static List<GenericTypesForController> GetIncludedEntities()
        {
            var typeList = new List<GenericTypesForController>();

            foreach (Assembly assembly in Assemblies)
            {
                Type[] types = assembly.GetTypes();

                foreach (Type type in types)
                {
                    if (type.GetCustomAttributes(typeof(ApiEntityAttribute), true).Length > 0)
                    {
                        typeList.Add(new GenericTypesForController
                        {
                            Entity = type.GetTypeInfo(),
                            Dto = (types.FirstOrDefault(x => x.Name == type.Name + "Dto") ??
                                   throw new InvalidOperationException($"No dto model found for {type.Name}"))
                                .GetTypeInfo(),
                            BlobDto = (types.FirstOrDefault(x => x.Name == "BlobDto") ??
                                       throw new InvalidOperationException($"No BlobDto model found for {type.Name}"))
                                .GetTypeInfo(),
                            Create = (types.FirstOrDefault(x => x.Name == "Create" + type.Name + "CommandModel") ??
                                      throw new InvalidOperationException($"No create model found for {type.Name}"))
                                .GetTypeInfo(),
                            Update = (types.FirstOrDefault(x => x.Name == "Update" + type.Name + "CommandModel") ??
                                      throw new InvalidOperationException($"No update model found for {type.Name}"))
                                .GetTypeInfo(),
                            Patch = (types.FirstOrDefault(x => x.Name == "Patch" + type.Name + "CommandModel") ??
                                     throw new InvalidOperationException($"No patch model found for {type.Name}"))
                                .GetTypeInfo(),
                        });
                    }
                }
            }

            return typeList;
        }
    }
}