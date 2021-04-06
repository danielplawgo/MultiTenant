using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MultiTenantDemo2.Data.TenantDb;

namespace MultiTenantDemo2.Tenants
{
    public class TenantAccessService : ITenantAccessService
    {
        private readonly ITenantResolutionStrategy _tenantResolutionStrategy;
        private readonly ITenantStore _tenantStore;
        private Tenant _currentTenant;

        public TenantAccessService(ITenantResolutionStrategy tenantResolutionStrategy, ITenantStore tenantStore)
        {
            _tenantResolutionStrategy = tenantResolutionStrategy;
            _tenantStore = tenantStore;
        }

        public async Task<Tenant> GetTenantAsync()
        {
            if (_currentTenant != null)
            {
                return _currentTenant;
            }

            var tenantIdentifier = await _tenantResolutionStrategy.GetTenantIdentifierAsync();
            _currentTenant = await _tenantStore.GetTenantAsync(tenantIdentifier);

            return _currentTenant;
        }
    }
}
