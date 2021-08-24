using System;

namespace DriverSecurity.Api.ViewModels
{
    public class ReportDangerRequestModel
    {
        public Guid DriverId { get; set; }
        public Guid Passenger { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string LicensePlate { get; set; }
    }
}