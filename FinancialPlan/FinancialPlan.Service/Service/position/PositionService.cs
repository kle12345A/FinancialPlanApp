using FinancialPlan.Entity.Entities;
using FinancialPlan.Repository.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPlan.Service.Service.position
{
    public class PositionService : BaseService<Position>, IPositionService
    {
        public PositionService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
