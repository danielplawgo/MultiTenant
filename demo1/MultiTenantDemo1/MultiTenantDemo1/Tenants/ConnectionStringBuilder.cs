using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace MultiTenantDemo1.Tenants
{
    public class ConnectionStringBuilder : IConnectionStringBuilder
    {
        private readonly ITenantAccessService _tenantAccessService;
        private readonly IConfiguration _configuration;

        public ConnectionStringBuilder(ITenantAccessService tenantAccessService,
            IConfiguration configuration)
        {
            _tenantAccessService = tenantAccessService;
            _configuration = configuration;
        }

        public async Task<string> BuildAsync()
        {
            var defaultConnection = _configuration.GetConnectionString("DefaultConnection");

            var tenant = await _tenantAccessService.GetTenantAsync();

            if (tenant == null)
            {
                return defaultConnection;
            }

            var builder = new SqlConnectionStringBuilder(defaultConnection);

            builder.InitialCatalog = tenant.Identifier;

            return builder.ConnectionString;
        }
    }

    public interface IConnectionStringBuilder
    {
        Task<string> BuildAsync();
    }
}
