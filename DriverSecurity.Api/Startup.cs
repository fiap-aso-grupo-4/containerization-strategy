using DriverSecurity.Api.Configuration;
using DriverSecurity.Api.Domain.Contracts.Repositories;
using DriverSecurity.Api.Domain.Contracts.Services;
using DriverSecurity.Api.HealthChecks;
using DriverSecurity.Api.Repositories;
using DriverSecurity.Api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace DriverSecurity.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<DangerReportDatabaseSettings>(
                Configuration.GetSection(nameof(DangerReportDatabaseSettings)));
            services.AddSingleton<IDangerReportDatabaseSettings>(x =>
                x.GetRequiredService<IOptions<DangerReportDatabaseSettings>>().Value);

            services.AddScoped<IDangerReportService, DangerReportService>();
            services.AddScoped<IDangerReportRepository, DangerReportRepository>();

            services.AddHealthChecks()
                .AddCheck<GlobalHealthCheck>("global_health_check");
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "DriverSecurity.Api", Version = "v1"});
            });
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", 
                    "DriverSecurity.Api v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });
        }
    }
}