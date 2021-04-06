using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MultiTenantDemo1.Data.TenantDb;

namespace MultiTenantDemo1.Tenants
{
    public class TenantService : ITenantService
    {
        private readonly TenantDataContext _db;

        public TenantService(TenantDataContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Tenant>> GetAllAsync()
        {
            return await _db.Tenants.ToListAsync();
        }
    }
}
