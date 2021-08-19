using System;
using System.Collections.Generic;
using DriverSecurity.Api.Domain.ValueObjects;

namespace DriverSecurity.Api.Domain.Entities
{
    public class DangerReport
    {
        public Guid EventId { get; set; }
        public Guid DriverId { get; set; }
        public Guid Passenger { get; set; }
        public IList<PositioningEvent> PositioningEvents { get; set; }
    }
}