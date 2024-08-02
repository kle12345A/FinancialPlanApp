using FinancialPlan.Entity.Contexts;
using FinancialPlan.Entity.Entities;
using FinancialPlan.Repository.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPlan.Repository.Repositories.planhistory
{
    internal class PlanHistoryRepository : BaseRepository<PlanHistory>
    {
        public PlanHistoryRepository(FinancialPlanDbContext context) : base(context)
        {
        }
    }
}
