using System;
using System.Threading.Tasks;
using DriverSecurity.Api.Domain.Entities;

namespace DriverSecurity.Api.Domain.Contracts.Repositories
{
    public interface IDangerReportRepository
    {
        Task<DangerReport> Create(DangerReport dangerReport);
        Task<DangerReport> UpdateLocation(Guid eventId, double latitude, double longitude, 
            DateTime eventDateTime, string aggressorPhotoPath);
    }
}