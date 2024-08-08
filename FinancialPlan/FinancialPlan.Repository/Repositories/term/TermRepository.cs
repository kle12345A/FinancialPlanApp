using FinancialPlan.Entity.Contexts;
using FinancialPlan.Entity.Entities;
using FinancialPlan.Repository.Infrastructures;

namespace FinancialPlan.Repository.Repositories.term
{
    public  class TermRepository : BaseRepository<Term>
    {
        public TermRepository(FinancialPlanDbContext context) : base(context)
        {
        }
    }
}
