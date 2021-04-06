using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MultiTenantDemo2.Data.TenantDb
{
    public class TenantDbContext : IdentityDbContext<User>
    {
        public DbSet<Tenant> Tenants { get; set; }

        public TenantDbContext(DbContextOptions<TenantDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("tenant");
        }
    }
}
