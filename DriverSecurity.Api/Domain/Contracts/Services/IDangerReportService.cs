using System.Threading.Tasks;
using DriverSecurity.Api.Domain.Entities;

namespace DriverSecurity.Api.Domain.Contracts.Services
{
    public interface IDangerReportService
    {
        Task<DangerReport> Create(string driverId, string passengerId, double latitude, double longitude, string aggressorFilePath);
        Task<DangerReport> UpdateLocation(string eventId, double latitude, double longitude, string aggressorFilePath);
    }
}