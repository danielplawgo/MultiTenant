using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;
using MultiTenantDemo1.Tenants;

namespace Microsoft.AspNetCore.Mvc.Rendering
{
    public static class IHtmlHelperExtensions
    {
        public static string GetTenant(this IHtmlHelper helper)
        {
            var tenantAccessService = helper.ViewContext.HttpContext.RequestServices.GetService<ITenantResolutionStrategy>();

            return tenantAccessService?.GetTenantIdentifier();
        }
    }
}
