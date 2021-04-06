using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace MultiTenantDemo2.Data.TenantDb
{
    public class User : IdentityUser
    {
        public virtual ICollection<Tenant> Tenants { get; set; }
    }
}