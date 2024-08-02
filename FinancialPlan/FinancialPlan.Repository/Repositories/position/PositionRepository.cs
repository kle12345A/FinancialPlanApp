using FinancialPlan.Entity.Contexts;
using FinancialPlan.Entity.Entities;
using FinancialPlan.Repository.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPlan.Repository.Repositories.position
{
    internal class PositionRepository : BaseRepository<Position>
    {
        public PositionRepository(FinancialPlanDbContext context) : base(context)
        {
        }
    }
}
