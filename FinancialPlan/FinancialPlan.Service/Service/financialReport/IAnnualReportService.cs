using FinancialPlan.Entity.Entities;
using FinancialPlan.Models.DTO;

namespace FinancialPlan.Service.Service.financialReport
{
    public interface IAnnualReportService : IBaseService<FinancialPlans>
    {
        Task<IEnumerable<AnnualReportDTO>> GetAllAnnualReportsAsync();
        Task<IEnumerable<AnnualReportDTO>> GetAnnualReportsByYearAsync(int year);
    }
}
