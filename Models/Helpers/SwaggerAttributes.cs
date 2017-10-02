using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternalPortal.Models.Helpers
{
    //[AttributeUsage(AttributeTargets.Method)]
    //public class SwaggerConsumesAttribute : Attribute
    //{
    //    public SwaggerConsumesAttribute(params string[] contentTypes)
    //    {
    //        this.ContentTypes = contentTypes;
    //    }

    //    public IEnumerable<string> ContentTypes { get; }
    //}

    //[AttributeUsage(AttributeTargets.Method)]
    //public class SwaggerProducesAttribute : Attribute
    //{
    //    public SwaggerProducesAttribute(params string[] contentTypes)
    //    {
    //        this.ContentTypes = contentTypes;
    //    }

    //    public IEnumerable<string> ContentTypes { get; }
    //}

    //public class ComsumesOperationFilter : IOperationFilter
    //{
    //    public void Apply(Operation operation, OperationFilterContext context)
    //    {
    //        var consumes = context.ApiDescription.ActionDescriptor.ActionConstraints.OfType<ConsumesAttribute>().FirstOrDefault();
    //        if (consumes != null)
    //        {
    //            operation.Consumes.Clear();
    //            foreach (var contentType in consumes.ContentTypes)
    //            {
    //                operation.Consumes.Add(contentType);
    //            }
    //        }
    //    }
    //}


}

