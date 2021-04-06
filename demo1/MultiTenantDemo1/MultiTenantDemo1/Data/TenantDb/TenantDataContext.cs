using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MultiTenantDemo1.Data.TenantDb
{
    public class TenantDataContext : DbContext
    {
        public TenantDataContext(DbContextOptions<TenantDataContext> options)
            : base(options)
        {
        }

        public DbSet<Tenant> Tenants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("tenant");
        }
    }
}
