using MongoDB.Bson;

namespace DriverSecurity.Api.Domain.Entities
{
    public class Passenger
    {
        public ObjectId _id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string DeviceId { get; set; }
    }
}