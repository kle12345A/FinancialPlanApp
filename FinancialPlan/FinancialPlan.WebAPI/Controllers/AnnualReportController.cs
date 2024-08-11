using FinancialPlan.Service.Service.financialReport;
using Microsoft.AspNetCore.Mvc;

namespace FinancialPlan.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnnualReportController : ControllerBase
    {
        private readonly IAnnualReportService _financialReportService;

        public AnnualReportController(IAnnualReportService financialReportService)
        {
            _financialReportService = financialReportService;
        }

        [HttpGet("annual-reports")]
        public async Task<IActionResult> GetAnnualReports()
        {
            var reports = await _financialReportService.GetAllAnnualReportsAsync();
            return Ok(reports);
        }

        [HttpGet("annual-reports/{year}")]
        public async Task<IActionResult> GetAnnualReportsByYear(int year)
        {
            var reports = await _financialReportService.GetAnnualReportsByYearAsync(year);

            if (reports == null || !reports.Any())
            {
                return NotFound("No items match your credentials, please try again.");
            }
            return Ok(reports);
        }

        [HttpGet("annual-reports/{year}/details")]
        public async Task<IActionResult> GetAnnualReportDetailsByDepartment(int year, [FromQuery] string departmentName)
        {
            var reportDetails = await _financialReportService.GetAnnualReportDetailsByDepartmentAsync(year, departmentName);

            if (reportDetails == null || !reportDetails.Any())
            {
                return NotFound("No items match your credentials, please try again.");
            }
            return Ok(reportDetails);
        }
    }
}
