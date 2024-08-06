using FinancialPlan.Entity.Entities;
using FinancialPlan.Service.Service.annualReport;
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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var reports = await _annualReportService.GetAllAsync();
            return Ok(reports);
        }

        // GET: api/annualreport/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var report = await _annualReportService.GetByIdAsync(id);
            if (report == null)
            {
                return NotFound();
            }
            return Ok(report);
        }
    }
}
