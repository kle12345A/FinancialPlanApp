using FinancialPlan.Entity.Entities;
using FinancialPlan.Repository.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPlan.Service.Service.term
{
    public class TermService : BaseService<Term>, ITermService
    {
        public TermService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
