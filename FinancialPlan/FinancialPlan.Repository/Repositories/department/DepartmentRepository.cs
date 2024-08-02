using FinancialPlan.Entity.Contexts;
using FinancialPlan.Entity.Entities;
using FinancialPlan.Repository.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPlan.Repository.Repositories.department
{
    public class DepartmentRepository : BaseRepository<Department>
    {
        public DepartmentRepository(FinancialPlanDbContext context) : base(context)
        {
        }
    }
}
