using FinancialPlan.Entity.Entities;
using FinancialPlan.Repository.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPlan.Service.Service.reportdetail
{
    public class ReportDetailService : BaseService<ReportDetail>, IReportDetailService
    {
        public ReportDetailService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
