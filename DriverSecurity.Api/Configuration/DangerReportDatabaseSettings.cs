namespace DriverSecurity.Api.Configuration
{
    public class DangerReportDatabaseSettings : IDangerReportDatabaseSettings
    {
        public string DangerReportCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}