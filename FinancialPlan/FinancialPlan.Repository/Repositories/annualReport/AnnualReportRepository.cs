using FinancialPlan.Entity.Contexts;
using FinancialPlan.Entity.Entities;
using FinancialPlan.Repository.Infrastructures;

namespace FinancialPlan.Repository.Repositories.annualReport
{
    internal class AnnualReportRepository : BaseRepository<AnnualReport>, IAnnualReportRepository
    {
        public AnnualReportRepository(FinancialPlanDbContext context) : base(context)
        {
        }
    }
}
