using Abp.Extensions;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Abp.AspNetCore.Mvc.Results.Caching
{
    [Obsolete]
    public class AllowClientCacheAttribute : IClientCacheAttribute
    {
        public ClientCacheScope? Scope { get; }

        public AllowClientCacheAttribute()
        {
            
        }

        public AllowClientCacheAttribute(ClientCacheScope scope)
        {
            Scope = scope;
        }

        public void Apply(ResultExecutingContext context)
        {
            if (Scope.HasValue)
            {
                context.HttpContext.Response.Headers["Cache-Control"] = Scope.ToString().ToCamelCase();
            }
        }
    }
}