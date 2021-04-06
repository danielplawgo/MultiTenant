using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic;

namespace MultiTenantDemo1.Tenants
{
    internal class TenantMiddleware
    {
        private readonly RequestDelegate next;

        public TenantMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var tenant = await GetTenant(context);

            if (tenant == null && IsNoTenantView(context) == false)
            {
                context.Response.Redirect("/");
                return;
            }

            if (tenant != null && context.User.Identity?.IsAuthenticated == true && !context.User.Identity.IsInTenant(tenant))
            {
                context.Response.Redirect("/");
                return;
            }

            //Continue processing
            if (next != null)
                await next(context);
        }

        private async Task<string> GetTenant(HttpContext context)
        {
            var service = context.RequestServices.GetService(typeof(ITenantResolutionStrategy)) as ITenantResolutionStrategy;

            return await service.GetTenantIdentifierAsync();
        }

        private bool IsNoTenantView(HttpContext context)
        {
            var action = context.Request.RouteValues["action"]?.ToString();
            var controller = context.Request.RouteValues["controller"]?.ToString();

            return action == "Index" && controller == "Home";
        }
    }
}
