using System;
using System.Collections.Generic;
using DriverSecurity.Api.Domain.ValueObjects;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DriverSecurity.Api.Domain.Entities
{
    public class DangerReport
    {
        [BsonId]
        public ObjectId _id { get; set; }
        public Guid EventId { get; set; }
        public Driver Driver { get; set; }
        public Passenger Passenger { get; set; }
        public IList<PositioningEvent> PositioningEvents { get; set; }
    }
}