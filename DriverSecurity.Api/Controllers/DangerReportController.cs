using System;
using System.IO;
using System.Threading.Tasks;
using DriverSecurity.Api.Domain.Contracts.Services;
using DriverSecurity.Api.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace DriverSecurity.Api.Controllers
{
    [Route("v1/danger-report")]
    [ApiController]
    public class DangerReportController : ControllerBase
    {
        private readonly IHostEnvironment _hostEnvironment;
        private readonly IDangerReportService _dangerReportService;
        
        public DangerReportController(IHostEnvironment hostEnvironment, IDangerReportService dangerReportService)
        {
            _hostEnvironment = hostEnvironment;
            _dangerReportService = dangerReportService;
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ReportDangerRequestModel dangerRequestModel, 
            IFormFile aggressorPhotoFile)
        {
            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id,
            [FromBody] ReportDangerRequestModel dangerRequestModel, IFormFile aggressorPhotoFile)
        {
            var uploads = Path.Combine(_hostEnvironment.ContentRootPath, "uploads");
            if (aggressorPhotoFile.Length <= 0) 
                return BadRequest("Aggressor photo could not be empty");
            
            var filePath = Path.Combine(uploads, aggressorPhotoFile.FileName);
            await using Stream fileStream = new FileStream(filePath, FileMode.Create);
            await aggressorPhotoFile.CopyToAsync(fileStream);

            var updatedEvent = await _dangerReportService.UpdateLocation(id, dangerRequestModel.Latitude, dangerRequestModel.Longitude,
                filePath);

            return Ok(updatedEvent);
        }
    }
}