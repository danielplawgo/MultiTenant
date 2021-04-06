using System.Collections.Generic;

namespace MultiTenantDemo1.Models.Home
{
    public class IndexViewModel
    {
        public IEnumerable<TenantViewModel> Tenants { get; set; }
    }
}
