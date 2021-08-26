namespace DriverSecurity.Api.ViewModels
{
    public class ReportDangerRequestModel
    {
        public string DriverId { get; set; }
        public string PassengerId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}