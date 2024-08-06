using FinancialPlan.Entity.Entities;
using FinancialPlan.Repository.Infrastructures;

namespace FinancialPlan.Service.Service.annualReport
{
    public class AnnualReportService : BaseService<AnnualReport>, IAnnualReportService
    {
        public AnnualReportService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public async Task<IEnumerable<AnnualReport>> GetAllAsync()
        {
            var reports = await base.GetAllAsync();
            return reports
                .OrderByDescending(r => r.Year)
                .Select(r => new AnnualReport
                {
                    Year = r.Year,
                    TotalExpense = r.TotalExpense,
                    TotalDepartments = r.TotalDepartments,
                    CreatedDate = r.CreatedDate,
                });
        }
    }
}
