using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MultiTenantDemo1.Models.Tenants;
using MultiTenantDemo1.Tenants;

namespace MultiTenantDemo1.Controllers
{
    public class TenantsController : Controller
    {
        private readonly ITenantAccessService _tenantAccessService;
        private readonly IConnectionStringBuilder _connectionStringBuilder;

        public TenantsController(ITenantAccessService tenantAccessService,
            IConnectionStringBuilder connectionStringBuilder)
        {
            _tenantAccessService = tenantAccessService;
            _connectionStringBuilder = connectionStringBuilder;
        }

        public async Task<IActionResult> Index()
        {
            var connection = await _connectionStringBuilder.BuildAsync();

            var tenant = await _tenantAccessService.GetTenantAsync();
            return View(new IndexViewModel()
            {
                Identifier = tenant.Identifier,
                Id = tenant.Id
            });
        }
    }
}
