using FinancialPlan.Entity.Contexts;
using FinancialPlan.Entity.Entities;
using FinancialPlan.Entity.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPlan.Repository.Infrastructures
{
    public class UnitOfWork : IUnitOfWork

    {
        private readonly FinancialPlanDbContext _context;
        private IBaseRepository<Department> _departmentRepository;
        private IBaseRepository<Expense> _expenseRepository;
        private IBaseRepository<FinancialPlans> _financialPlanRepository;
        private IBaseRepository<MonthlyExpenseReport> _monthlyExpenseReportRepository;
        private IBaseRepository<PlanHistory> _planHistoryRepository;
        private IBaseRepository<Position> _positionRepository;
        private IBaseRepository<ReportDetail> _reportDetailRepository;
        private IBaseRepository<ReportHistory> _reportHistoryRepository;
        private IBaseRepository<Term> _termRepository;

        public UnitOfWork(FinancialPlanDbContext context)
        {
            _context = context;
        }

        public FinancialPlanDbContext DataContext => _context;

        public IBaseRepository<Department> DepartmentRepository
            => _departmentRepository ??= new BaseRepository<Department>(_context);

        public IBaseRepository<Expense> ExpenseRepository
            => _expenseRepository ??= new BaseRepository<Expense>(_context);

        public IBaseRepository<FinancialPlans> FinancialPlanRepository
            => _financialPlanRepository ??= new BaseRepository<FinancialPlans>(_context);

        public IBaseRepository<MonthlyExpenseReport> MonthlyExpenseReportRepository
            => _monthlyExpenseReportRepository ??= new BaseRepository<MonthlyExpenseReport>(_context);

        public IBaseRepository<PlanHistory> PlanHistoryRepository
            => _planHistoryRepository ??= new BaseRepository<PlanHistory>(_context);

        public IBaseRepository<Position> PositionRepository
            => _positionRepository ??= new BaseRepository<Position>(_context);

        public IBaseRepository<ReportDetail> ReportDetailRepository
            => _reportDetailRepository ??= new BaseRepository<ReportDetail>(_context);

        public IBaseRepository<ReportHistory> ReportHistoryRepository
            => _reportHistoryRepository ??= new BaseRepository<ReportHistory>(_context);

      

        public IBaseRepository<Term> TermRepository
            => _termRepository ??= new BaseRepository<Term>(_context);

        public IBaseRepository<Role> RoleRepository => throw new NotImplementedException();

        public IBaseRepository<User> UserRepository => throw new NotImplementedException();

        public IBaseRepository<UserRole> UserRoleRepository => throw new NotImplementedException();

        public IBaseRepository<TEntity> BaseRepository<TEntity>() where TEntity : BaseEntity
            => new BaseRepository<TEntity>(_context);

        public Task BeginTransactionAsync()
        {
            // Implement the transaction logic here
            return _context.Database.BeginTransactionAsync();
        }

        public Task CommitTransactionAsync()
        {
            // Implement the commit logic here
            return _context.Database.CurrentTransaction.CommitAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public Task RollbackTransactionAsync()
        {
            // Implement the rollback logic here
            return _context.Database.CurrentTransaction.RollbackAsync();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
