using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MultiTenantDemo1.Data.TenantDb;

namespace MultiTenantDemo1.Tenants
{
    public static class ServiceCollectionExtensions
    {
        public static TenantBuilder<T> AddMultiTenancy<T>(this IServiceCollection services) where T : Tenant
            => new TenantBuilder<T>(services);

        public static TenantBuilder<Tenant> AddMultiTenancy(this IServiceCollection services)
            => new TenantBuilder<Tenant>(services);
    }
}
