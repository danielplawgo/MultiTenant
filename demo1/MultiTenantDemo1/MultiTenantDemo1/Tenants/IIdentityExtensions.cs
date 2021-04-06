using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace System.Security.Principal
{
    public static class IIdentityExtensions
    {
        public static bool IsInTenant(this IIdentity identity, string tenant)
        {
            var userTenant = identity.GetTenant();

            return userTenant == tenant;
        }

        public static string GetTenant(this IIdentity identity)
        {
            var claimIdentity = identity as ClaimsIdentity;

            var userTenant = claimIdentity?.FindFirst("tenant")?.Value;

            return userTenant;
        }
    }
}
