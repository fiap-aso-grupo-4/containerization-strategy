using System;
using Microsoft.AspNetCore.Http;

namespace DriverSecurity.Api.ViewModels
{
    public class ReportDangerRequestModel
    {
        public Guid DriverId { get; set; }
        public Guid Passenger { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string LicensePlate { get; set; }
        public IFormFile AggressorPhoto { get; set; }
    }
}