using FinancialPlan.Entity.Contexts;
using FinancialPlan.Entity.Entities;
using FinancialPlan.Entity.Entities.Base;

namespace FinancialPlan.Repository.Infrastructures
{
    public class UnitOfWork : IUnitOfWork

    {
        private readonly FinancialPlanDbContext _context;
        private IBaseRepository<Department> _departmentRepository;
        private IBaseRepository<FinancialPlans> _financialPlanRepository;
        private IBaseRepository<Term> _termRepository;

        public UnitOfWork(FinancialPlanDbContext context)
        {
            _context = context;
        }

        public FinancialPlanDbContext DataContext => _context;

        public IBaseRepository<Department> DepartmentRepository
            => _departmentRepository ??= new BaseRepository<Department>(_context);

        public IBaseRepository<FinancialPlans> FinancialPlanRepository
            => _financialPlanRepository ??= new BaseRepository<FinancialPlans>(_context);

        public IBaseRepository<Term> TermRepository
            => _termRepository ??= new BaseRepository<Term>(_context);

        public IBaseRepository<Role> RoleRepository => throw new NotImplementedException();

        public IBaseRepository<User> UserRepository => throw new NotImplementedException();

        public IBaseRepository<UserRole> UserRoleRepository => throw new NotImplementedException();

        public IBaseRepository<TEntity> BaseRepository<TEntity>() where TEntity : BaseEntity
            => new BaseRepository<TEntity>(_context);

        public Task BeginTransactionAsync()
        {
            return _context.Database.BeginTransactionAsync();
        }

        public Task CommitTransactionAsync()
        {
            return _context.Database.CurrentTransaction.CommitAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public Task RollbackTransactionAsync()
        {
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
