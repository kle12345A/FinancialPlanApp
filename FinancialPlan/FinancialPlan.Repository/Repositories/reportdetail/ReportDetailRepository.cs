using FinancialPlan.Entity.Contexts;
using FinancialPlan.Entity.Entities;
using FinancialPlan.Repository.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPlan.Repository.Repositories.reportdetail
{
    public class ReportDetailRepository : BaseRepository<ReportDetail>
    {
        public ReportDetailRepository(FinancialPlanDbContext context) : base(context)
        {
        }
    }
}
