using FinancialPlan.Entity.Entities;
using FinancialPlan.Models.DTO;
using FinancialPlan.Repository.Infrastructures;
using FinancialPlan.Repository.Repositories.financialReport;

namespace FinancialPlan.Service.Service.financialReport
{
    public class AnnualReportService : BaseService<FinancialPlans>, IAnnualReportService
    {
        private readonly IAnnualReportRepository _annualReportRepository;

        public AnnualReportService(IUnitOfWork unitOfWork, IAnnualReportRepository annualReportRepository)
            : base(unitOfWork)
        {
            _annualReportRepository = annualReportRepository;
        }

        public async Task<IEnumerable<AnnualReportDTO>> GetAllAnnualReportsAsync()
        {
            return await _annualReportRepository.GetAllAnnualReportsAsync();
        }

        public async Task<IEnumerable<AnnualReportDTO>> GetAnnualReportsByYearAsync(int year)
        {
            return await _annualReportRepository.GetAnnualReportsByYearAsync(year);
        }

        public async Task<IEnumerable<AnnualReportDetailDTO>> GetAnnualReportDetailsByDepartmentAsync(int year, string departmentName)
        {
            return await _annualReportRepository.GetAnnualReportDetailsByDepartmentAsync(year, departmentName);
        }

        public async Task<byte[]> ExportAnnualExpenseReportAsync(int year)
        {
            return await _annualReportRepository.ExportAnnualExpenseReportAsync(year);
        }
    }
}
