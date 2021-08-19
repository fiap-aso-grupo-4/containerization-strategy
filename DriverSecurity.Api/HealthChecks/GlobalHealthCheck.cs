using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace DriverSecurity.Api.HealthChecks
{
    public class GlobalHealthCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, 
            CancellationToken cancellationToken = new ())
        {
            return Task.FromResult(
                HealthCheckResult.Healthy("Healthy."));
        }
    }
}