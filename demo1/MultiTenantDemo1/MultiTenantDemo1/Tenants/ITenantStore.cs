using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MultiTenantDemo1.Data.TenantDb;

namespace MultiTenantDemo1.Tenants
{
    public interface ITenantStore
    {
        Task<Tenant> GetTenantAsync(string identifier);
    }
}
