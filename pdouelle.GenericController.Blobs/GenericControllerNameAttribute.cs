using System;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using pdouelle.GenericController.Blob.Controllers;

namespace pdouelle.GenericController.Blob
{
    [AttributeUsage(AttributeTargets.Class)]
    public class GenericControllerNameAttribute : Attribute, IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            var isGenericController = controller.ControllerType.GenericTypeArguments.Length > 0;

            if (isGenericController)
            {
                if (controller.ControllerType.GetGenericTypeDefinition() == typeof(GenericControllerWithBlobs<,,,,,,,,,>))
                {
                    Type entityType = controller.ControllerType.GenericTypeArguments[0];
                    controller.ControllerName = entityType.Name + "s";
                }
            }
        }
    }
}