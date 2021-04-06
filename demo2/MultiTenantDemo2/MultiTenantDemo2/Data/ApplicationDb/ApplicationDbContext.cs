using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MultiTenantDemo2.Tenants;
using Z.EntityFramework.Plus;

namespace MultiTenantDemo2.Data.ApplicationDb
{
    public class ApplicationDbContext : DbContext
    {
        private readonly Guid _tenantId;

        public DbSet<Product> Products { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ITenantResolutionStrategy tenantResolutionStrategy)
            : base(options)
        {
            _tenantId = tenantResolutionStrategy.GetTenantIdentifier();

            if (_tenantId != Guid.Empty)
            {
                this.Filter<Model>(q => q.Where(m => m.TenantId == _tenantId));
            }
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added);

            foreach (var entry in entries)
            {
                var model = entry.Entity as Model;

                if (model == null)
                {
                    continue;
                }

                model.TenantId = _tenantId;
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
