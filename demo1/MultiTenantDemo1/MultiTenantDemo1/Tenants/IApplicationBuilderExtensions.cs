using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using MultiTenantDemo1.Data.TenantDb;

namespace MultiTenantDemo1.Tenants
{
    public static class IApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseMultiTenancy(this IApplicationBuilder builder)
            => builder.UseMiddleware<TenantMiddleware>();
    }
}
