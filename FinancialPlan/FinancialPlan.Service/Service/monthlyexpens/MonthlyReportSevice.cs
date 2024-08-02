using FinancialPlan.Entity.Entities;
using FinancialPlan.Repository.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPlan.Service.Service.monthlyexpens
{
    public class MonthlyExpenseReportService : BaseService<MonthlyExpenseReport>, IMonthlyExpenseReportService
    {
        public MonthlyExpenseReportService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
