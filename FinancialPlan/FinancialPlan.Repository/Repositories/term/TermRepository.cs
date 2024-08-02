using FinancialPlan.Entity.Contexts;
using FinancialPlan.Entity.Entities;
using FinancialPlan.Repository.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPlan.Repository.Repositories.term
{
    public  class TermRepository : BaseRepository<Term>
    {
        public TermRepository(FinancialPlanDbContext context) : base(context)
        {
        }
    }
}
