using System.Collections.Generic;
using DriverSecurity.Api.Domain.ValueObjects;
using MongoDB.Bson.Serialization.Attributes;

namespace DriverSecurity.Api.Domain.Entities
{
    public class DangerReport
    {
        [BsonId]
        public string _id { get; set; }
        public string EventId { get; set; }
        public Driver Driver { get; set; }
        public Passenger Passenger { get; set; }
        public IList<PositioningEvent> PositioningEvents { get; set; }
    }
}