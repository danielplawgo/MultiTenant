using System;
using System.Collections.Generic;

namespace MultiTenantDemo2.Data.TenantDb
{
    public class Tenant
    {
        public Guid Id { get; set; }

        public string Identifier { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}