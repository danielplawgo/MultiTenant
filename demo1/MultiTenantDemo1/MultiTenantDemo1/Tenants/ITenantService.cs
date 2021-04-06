using System.Collections.Generic;
using System.Threading.Tasks;
using MultiTenantDemo1.Data.TenantDb;

namespace MultiTenantDemo1.Tenants
{
    public interface ITenantService
    {
        Task<IEnumerable<Tenant>> GetAllAsync();
    }
}