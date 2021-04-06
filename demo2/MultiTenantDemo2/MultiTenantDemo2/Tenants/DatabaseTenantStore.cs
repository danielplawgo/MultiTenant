using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MultiTenantDemo2.Data.TenantDb;

namespace MultiTenantDemo2.Tenants
{
    public class DatabaseTenantStore : ITenantStore
    {
        private readonly TenantDbContext _db;

        public DatabaseTenantStore(TenantDbContext db)
        {
            _db = db;
        }

        public async Task<Tenant> GetTenantAsync(Guid id)
        {
            if (Guid.Empty == id)
            {
                return null;
            }

            return await _db.Tenants.FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}