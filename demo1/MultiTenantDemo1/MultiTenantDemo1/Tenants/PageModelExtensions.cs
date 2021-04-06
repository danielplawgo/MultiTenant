using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using MultiTenantDemo1.Tenants;

namespace Microsoft.AspNetCore.Mvc.RazorPages
{
    public static class PageModelExtensions
    {
        public static string GetTenant(this PageModel pageModel)
        {
            var tenantAccessService = pageModel.HttpContext.RequestServices.GetService<ITenantResolutionStrategy>();

            return tenantAccessService?.GetTenantIdentifier();
        }
    }
}
