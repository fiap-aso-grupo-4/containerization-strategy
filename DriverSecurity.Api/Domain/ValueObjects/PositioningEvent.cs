using System;
using MongoDB.Driver.GeoJsonObjectModel;

namespace DriverSecurity.Api.Domain.ValueObjects
{
    public struct PositioningEvent
    {
        public string EventId { get; set; }
        public DateTime EventDateTime { get; set; }
        public GeoJson2DGeographicCoordinates  Coordinates { get; set; }
        public string AggressorPhotoPath { get; set; }
    }
}