namespace DriverSecurity.Api.Configuration
{
    public interface IDangerReportDatabaseSettings
    {
        string DangerReportCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}