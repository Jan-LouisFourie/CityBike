using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityBike.DTO;
using CityBike.Services;
using Microsoft.AspNetCore.Mvc;

namespace CityBike.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportsController(ReportService reportService) : ControllerBase
    {
        private readonly ReportService reportService = reportService;

        [HttpGet("revenue")]
        public IActionResult GetRevenue([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            RevenueReport report = reportService.GenerateRevenueReport(startDate, endDate);
            return Ok(report);
        }
    }
}