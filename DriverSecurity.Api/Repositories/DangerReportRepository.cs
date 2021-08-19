using System;
using System.Threading.Tasks;
using DriverSecurity.Api.Configuration;
using DriverSecurity.Api.Domain.Contracts.Repositories;
using DriverSecurity.Api.Domain.Entities;
using DriverSecurity.Api.Domain.ValueObjects;
using MongoDB.Driver;

namespace DriverSecurity.Api.Repositories
{
    public class DangerReportRepository : IDangerReportRepository
    {
        private readonly IMongoCollection<DangerReport> _dangerReports;

        public DangerReportRepository(IDangerReportDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _dangerReports = database.GetCollection<DangerReport>(settings.DangerReportCollectionName);
        }

        public async Task<DangerReport> Create(DangerReport dangerReport)
        {
            await _dangerReports.InsertOneAsync(dangerReport);
            return dangerReport;
        }

        public async Task<DangerReport> UpdateLocation(Guid eventId, string latitude, string longitude, 
            DateTime eventDateTime, string aggressorPhotoPath)
        {
            var dangerReports = await _dangerReports.FindAsync(x => 
                x.EventId == eventId);
            var report = dangerReports.FirstOrDefault();
            
            report.PositioningEvents.Add(new PositioningEvent
            {
                EventDateTime = eventDateTime,
                Latitude = latitude,
                Longitude = longitude,
                AggressorPhotoPath = aggressorPhotoPath
            });

            await _dangerReports.ReplaceOneAsync(x => x.EventId == eventId, report);
            return report;
        }
    }
}