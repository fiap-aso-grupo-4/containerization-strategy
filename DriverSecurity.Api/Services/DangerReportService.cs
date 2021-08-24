using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DriverSecurity.Api.Domain.Contracts.Repositories;
using DriverSecurity.Api.Domain.Contracts.Services;
using DriverSecurity.Api.Domain.Entities;
using DriverSecurity.Api.Domain.ValueObjects;
using MongoDB.Driver.GeoJsonObjectModel;

namespace DriverSecurity.Api.Services
{
    public class DangerReportService : IDangerReportService
    {
        private readonly IDangerReportRepository _reportRepository;
        public DangerReportService(IDangerReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }
        
        public async Task<DangerReport> Create(Guid driverId, Guid passengerId, double latitude, double longitude,
            string aggressorFilePath)
        {
            var dangerReport = new DangerReport
            {
                EventId = Guid.NewGuid(),
                Driver = new Driver
                {
                    
                },
                Passenger = new Passenger
                {
                    
                },
                PositioningEvents = new List<PositioningEvent>
                {
                    new()
                    {
                        EventDateTime = DateTime.Now,
                        Coordinates = new GeoJson2DGeographicCoordinates(latitude, longitude), 
                        AggressorPhotoPath = string.Empty
                    }
                }
            };
            
            return await _reportRepository.Create(dangerReport);
        }

        public async Task<DangerReport> UpdateLocation(Guid eventId, double latitude, double longitude, string aggressorFilePath)
        {
            return await _reportRepository.UpdateLocation(eventId, latitude, longitude, DateTime.Now,
                aggressorFilePath);
        }
    }
}