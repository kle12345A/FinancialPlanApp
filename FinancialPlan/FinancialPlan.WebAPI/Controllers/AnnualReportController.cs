using FinancialPlan.Service.Service.financialReport;
using Microsoft.AspNetCore.Mvc;

namespace FinancialPlan.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnnualReportController : ControllerBase
    {
        private readonly IAnnualReportService _annualReportService;

        public AnnualReportController(IAnnualReportService annualReportService)
        {
            _annualReportService = annualReportService;
        }

        [HttpGet("annual-reports")]
        public async Task<IActionResult> GetAnnualReports()
        {
            var reports = await _annualReportService.GetAllAnnualReportsAsync();
            return Ok(reports);
        }

        [HttpGet("annual-reports/{year}")]
        public async Task<IActionResult> GetAnnualReportsByYear(int year)
        {
            var reports = await _annualReportService.GetAnnualReportsByYearAsync(year);

            if (reports == null || !reports.Any())
            {
                return NotFound("No items match your credentials, please try again.");
            }
            return Ok(reports);
        }

        [HttpGet("annual-reports/{year}/details")]
        public async Task<IActionResult> GetAnnualReportDetailsByDepartment(int year, [FromQuery] string departmentName)
        {
            var reportDetails = await _annualReportService.GetAnnualReportDetailsByDepartmentAsync(year, departmentName);

            if (reportDetails == null || !reportDetails.Any())
            {
                return NotFound("No items match your credentials, please try again.");
            }
            return Ok(reportDetails);
        }
        [HttpGet("export/{year}")]
        public async Task<IActionResult> ExportAnnualExpenseReport(int year)
        {
            var fileContent = await _annualReportService.ExportAnnualExpenseReportAsync(year);
            if (fileContent == null)
            {
                return NotFound();
            }

            var fileName = $"AnnualExpenseReport_{year}.xlsx";
            return File(fileContent, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }
    }
}
