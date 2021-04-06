using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace MultiTenantDemo2.Tenants
{
    public static class IIdentityExtensions
    {
        public static Guid GetTenant(this IIdentity identity)
        {
            var claimIdentity = identity as ClaimsIdentity;

            var userTenant = claimIdentity?.FindFirst("tenant")?.Value;

            if (userTenant == null)
            {
                return Guid.Empty;
            }

            return Guid.Parse(userTenant);
        }
    }
}
