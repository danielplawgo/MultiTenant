using Microsoft.AspNetCore.Builder;

namespace MultiTenantDemo2.Tenants
{
    public static class IApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseMultiTenancy(this IApplicationBuilder builder)
            => builder.UseMiddleware<TenantMiddleware>();
    }
}