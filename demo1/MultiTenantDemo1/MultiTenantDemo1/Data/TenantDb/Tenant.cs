using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiTenantDemo1.Data.TenantDb
{
    public class Tenant
    {
        public Guid Id { get; set; }

        public string Identifier { get; set; }
    }
}
