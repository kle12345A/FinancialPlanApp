﻿using FinancialPlan.Entity.Entities;
using FinancialPlan.Repository.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPlan.Service.Service.expense
{
    public class ExpenseService : BaseService<Expense>, IExpenseService
    {
        public ExpenseService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
