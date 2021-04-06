using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiTenantDemo2.Tenants
{
    public interface ITenantResolutionStrategy
    {
        Task<Guid> GetTenantIdentifierAsync();

        Guid GetTenantIdentifier();
    }
}
