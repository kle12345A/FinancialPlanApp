using FinancialPlan.Entity.Contexts;
using FinancialPlan.Entity.Entities;
using FinancialPlan.Repository.Infrastructures;

namespace FinancialPlan.Repository.Repositories.financialplans
{
    internal class FinancialPlansRepository : BaseRepository<FinancialPlans>
    {
        public FinancialPlansRepository(FinancialPlanDbContext context) : base(context)
        {
        }
    }
}
