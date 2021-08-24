using MongoDB.Bson;

namespace DriverSecurity.Api.Domain.Entities
{
    public class Driver
    {
        public ObjectId _id { get; set; }
        public string Name { get; set; }
        public string Cnh { get; set; }
        public string DeviceId { get; set; }
    }
}