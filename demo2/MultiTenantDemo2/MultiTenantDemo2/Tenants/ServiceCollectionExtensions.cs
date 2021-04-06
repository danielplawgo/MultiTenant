using Microsoft.Extensions.DependencyInjection;
using MultiTenantDemo2.Data.TenantDb;

namespace MultiTenantDemo2.Tenants
{
    public static class ServiceCollectionExtensions
    {
        public static TenantBuilder<T> AddMultiTenancy<T>(this IServiceCollection services) where T : Tenant
            => new TenantBuilder<T>(services);

        public static TenantBuilder<Tenant> AddMultiTenancy(this IServiceCollection services)
            => new TenantBuilder<Tenant>(services);
    }
}