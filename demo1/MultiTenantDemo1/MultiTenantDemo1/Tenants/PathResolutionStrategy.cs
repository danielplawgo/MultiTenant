using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MultiTenantDemo1.Tenants
{
    public class PathResolutionStrategy : ITenantResolutionStrategy
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PathResolutionStrategy(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Task<string> GetTenantIdentifierAsync()
        {
            return Task.FromResult(GetTenantIdentifier());
        }

        public string GetTenantIdentifier()
        {
            if (_httpContextAccessor.HttpContext?.Request.RouteValues.ContainsKey("tenant") == false)
            {
                return null;
            }

            var tenant = _httpContextAccessor.HttpContext?.Request.RouteValues["tenant"]?.ToString();

            if (tenant == null || tenant == "none")
            {
                return null;
            }

            return tenant;
        }
    }
}
