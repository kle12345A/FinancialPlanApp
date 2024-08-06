using FinancialPlan.Entity.Contexts;
using FinancialPlan.Entity.Entities;
using FinancialPlan.Entity.Entities.Base;

namespace FinancialPlan.Repository.Infrastructures
{
    public interface IUnitOfWork : IDisposable
    {
        FinancialPlanDbContext DataContext { get; }
        int SaveChanges();
        Task<int> SaveChangesAsync();
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();

        IBaseRepository<Department> DepartmentRepository { get; }
        IBaseRepository<Expense> ExpenseRepository { get; }
        IBaseRepository<FinancialPlans> FinancialPlanRepository { get; }
        IBaseRepository<MonthlyExpenseReport> MonthlyExpenseReportRepository { get; }
        IBaseRepository<AnnualReport> AnnualExpenseReportRepository { get; }
        IBaseRepository<PlanHistory> PlanHistoryRepository { get; }
        IBaseRepository<Position> PositionRepository { get; }
        IBaseRepository<ReportDetail> ReportDetailRepository { get; }
        IBaseRepository<ReportHistory> ReportHistoryRepository { get; }
        IBaseRepository<Role> RoleRepository { get; }
        IBaseRepository<Term> TermRepository { get; }
        IBaseRepository<User> UserRepository { get; }
        IBaseRepository<UserRole> UserRoleRepository { get; }

        IBaseRepository<TEntity> BaseRepository<TEntity>() where TEntity : BaseEntity;
    }
}
