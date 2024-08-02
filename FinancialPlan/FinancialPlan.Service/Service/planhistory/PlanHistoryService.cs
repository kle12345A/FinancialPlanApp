using FinancialPlan.Entity.Entities;
using FinancialPlan.Repository.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPlan.Service.Service.planhistory
{
    public class PlanHistoryService : BaseService<PlanHistory>, IPlanHistoryService
    {
        public PlanHistoryService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
