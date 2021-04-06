using System.Threading.Tasks;
using MultiTenantDemo1.Data.TenantDb;

namespace MultiTenantDemo1.Tenants
{
    public interface ITenantAccessService
    {
        Task<Tenant> GetTenantAsync();
    }
}