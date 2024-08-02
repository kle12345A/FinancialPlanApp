using FinancialPlan.Entity.Entities;
using FinancialPlan.Repository.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPlan.Service.Service.reporthistory
{
    public class ReportHistoryService : BaseService<ReportHistory>, IReportHistoryService
    {
        public ReportHistoryService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
