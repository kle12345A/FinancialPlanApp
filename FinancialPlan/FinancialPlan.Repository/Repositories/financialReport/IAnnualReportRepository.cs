using FinancialPlan.Entity.Entities;
using FinancialPlan.Models.DTO;
using FinancialPlan.Repository.Infrastructures;

namespace FinancialPlan.Repository.Repositories.financialReport
{
    public interface IAnnualReportRepository : IBaseRepository<FinancialPlans>
    {
        Task<IEnumerable<AnnualReportDTO>> GetAllAnnualReportsAsync();
        Task<IEnumerable<AnnualReportDTO>> GetAnnualReportsByYearAsync(int year);
        Task<IEnumerable<AnnualReportDetailDTO>> GetAnnualReportDetailsByDepartmentAsync(int year, string departmentName);
        Task<byte[]> ExportAnnualExpenseReportAsync(int year);
    }
}
