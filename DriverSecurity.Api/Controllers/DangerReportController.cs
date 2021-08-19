using System;
using System.Threading.Tasks;
using DriverSecurity.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DriverSecurity.Api.Controllers
{
    [Route("v1/danger-report")]
    [ApiController]
    public class DangerReportController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ReportDangerRequestModel dangerRequestModel)
        {
            return Accepted();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id,
            [FromBody] ReportDangerRequestModel dangerRequestModel)
        {
            return Accepted();
        }
    }
}