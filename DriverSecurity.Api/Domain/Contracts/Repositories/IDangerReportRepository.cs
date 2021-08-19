using System.Threading.Tasks;
using DriverSecurity.Api.Domain.Entities;

namespace DriverSecurity.Api.Domain.Contracts.Repositories
{
    public interface IDangerReportRepository
    {
        Task<DangerReport> Create(DangerReport dangerReport);
    }
}