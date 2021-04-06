using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MultiTenantDemo2.Tenants
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

            if (tenant == Guid.Empty && IsNoTenantView(context) == false)
            {
                context.Response.Redirect("/");
                return;
            }

            //Continue processing
            if (next != null)
                await next(context);
        }

        private async Task<Guid> GetTenant(HttpContext context)
        {
            var service = context.RequestServices.GetService(typeof(ITenantResolutionStrategy)) as ITenantResolutionStrategy;

            return await service.GetTenantIdentifierAsync();
        }

        private bool IsNoTenantView(HttpContext context)
        {
            var action = context.Request.RouteValues["action"]?.ToString();
            var controller = context.Request.RouteValues["controller"]?.ToString();
            var page = context.Request.RouteValues["page"]?.ToString();

            var actions = new Dictionary<string, string>()
            {
                {"Home", "Index"},
            };

            var pages = new List<string>()
            {
                "/Account/Login",
                "/Account/Register",
                "/Account/Logout"
            };

            return actions.Any(i => i.Key == controller && i.Value == action) || pages.Any(p => p == page);
        }
    }
}