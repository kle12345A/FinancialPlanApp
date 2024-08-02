using FinancialPlan.Repository.Infrastructures;
using FinancialPlan.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPlan.Service.Service.financialplans
{
    public class FinancialPlanService : BaseService<FinancialPlans>, IFinancialPlanService
    {
        public FinancialPlanService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
