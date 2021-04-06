using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MultiTenantDemo2.Data.TenantDb;

namespace MultiTenantDemo2.Tenants
{
    public interface ITenantAccessService
    {
        Task<Tenant> GetTenantAsync();
    }
}
