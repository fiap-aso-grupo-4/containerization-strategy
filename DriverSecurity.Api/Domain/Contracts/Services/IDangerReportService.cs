using System;
using System.Threading.Tasks;
using DriverSecurity.Api.Domain.Entities;

namespace DriverSecurity.Api.Domain.Contracts.Services
{
    public interface IDangerReportService
    {
        Task<DangerReport> Create(Guid driverId, Guid passengerId, double latitude, double longitude, string aggressorFilePath);
        Task<DangerReport> UpdateLocation(Guid eventId, double latitude, double longitude, string aggressorFilePath);
    }
}