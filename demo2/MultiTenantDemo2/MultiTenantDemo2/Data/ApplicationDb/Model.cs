using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiTenantDemo2.Data.ApplicationDb
{
    public class Model
    {
        public Guid Id { get; set; }

        public Guid TenantId { get; set; }
    }
}
