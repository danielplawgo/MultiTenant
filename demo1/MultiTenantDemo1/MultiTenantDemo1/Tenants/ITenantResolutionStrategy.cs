using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiTenantDemo1.Tenants
{
    public interface ITenantResolutionStrategy
    {
        Task<string> GetTenantIdentifierAsync();

        string GetTenantIdentifier();
    }
}
