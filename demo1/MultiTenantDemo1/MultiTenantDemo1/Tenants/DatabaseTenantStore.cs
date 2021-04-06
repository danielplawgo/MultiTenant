using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MultiTenantDemo1.Data.TenantDb;

namespace MultiTenantDemo1.Tenants
{
    public class DatabaseTenantStore : ITenantStore
    {
        private readonly TenantDataContext _db;

        public DatabaseTenantStore(TenantDataContext db)
        {
            _db = db;
        }

        public async Task<Tenant> GetTenantAsync(string identifier)
        {
            if (string.IsNullOrEmpty(identifier))
            {
                return null;
            }
            
            return await _db.Tenants.FirstOrDefaultAsync(t => t.Identifier.ToLower() == identifier.ToLower());
        }
    }
}
