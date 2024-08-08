using FinancialPlan.Entity.Contexts;
using FinancialPlan.Entity.Entities;
using FinancialPlan.Repository.Infrastructures;

namespace FinancialPlan.Repository.Repositories.department
{
    public class DepartmentRepository : BaseRepository<Department>
    {
        public DepartmentRepository(FinancialPlanDbContext context) : base(context)
        {
        }
    }
}
