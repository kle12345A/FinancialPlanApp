using FinancialPlan.Repository.Infrastructures;
using FinancialPlan.Entity.Entities;

namespace FinancialPlan.Service.Service.financialplans
{
    public class FinancialPlanService : BaseService<FinancialPlans>, IFinancialPlanService
    {
        public FinancialPlanService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
