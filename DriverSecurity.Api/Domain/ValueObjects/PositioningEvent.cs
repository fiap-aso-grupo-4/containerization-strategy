using System;

namespace DriverSecurity.Api.Domain.ValueObjects
{
    public struct PositioningEvent
    {
        public DateTime EventDateTime { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string AggressorPhotoPath { get; set; }
    }
}