using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MultiTenantDemo2.Tenants
{
    public class ClaimResolutionStrategy : ITenantResolutionStrategy
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ClaimResolutionStrategy(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Task<Guid> GetTenantIdentifierAsync()
        {
            return Task.FromResult(GetTenantIdentifier());
        }

        public Guid GetTenantIdentifier()
        {
            if (_httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated == true)
            {
                return _httpContextAccessor.HttpContext.User.Identity.GetTenant();
            }

            return Guid.Empty;
        }
    }
}
