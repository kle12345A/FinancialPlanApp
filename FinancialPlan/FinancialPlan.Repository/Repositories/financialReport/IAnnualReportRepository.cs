using FinancialPlan.Entity.Entities;
using FinancialPlan.Models.DTO;
using FinancialPlan.Repository.Infrastructures;

namespace FinancialPlan.Repository.Repositories.financialReport
{
    public interface IAnnualReportRepository : IBaseRepository<FinancialPlans>
    {
        Task<IEnumerable<AnnualReportDTO>> GetAllAnnualReportsAsync();
        Task<IEnumerable<AnnualReportDTO>> GetAnnualReportsByYearAsync(int year);
        Task<IEnumerable<ReportDetailDTO>> GetAnnualReportDetailsByDepartmentAsync(int year, string departmentName);
    }
}
