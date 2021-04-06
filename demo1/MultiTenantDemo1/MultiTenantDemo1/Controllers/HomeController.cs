using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MultiTenantDemo1.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MultiTenantDemo1.Models.Home;
using MultiTenantDemo1.Tenants;

namespace MultiTenantDemo1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITenantService _tenantService;

        public HomeController(ILogger<HomeController> logger, ITenantService tenantService)
        {
            _logger = logger;
            _tenantService = tenantService;
        }

        public async Task<IActionResult> Index()
        {
            var tenants = await _tenantService.GetAllAsync();

            return View(new IndexViewModel()
            {
                Tenants = tenants.Select(t => new TenantViewModel()
                {
                    Identifier = t.Identifier,
                    Id = t.Id
                })
            });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
