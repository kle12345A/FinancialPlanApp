using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPlan.Repository.Infrastructures
{
    public interface IBaseRepository<T>
    {
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        T GetById(Guid id);
        Task<T> GetByIdAsync(Guid id);

        int Add(T entity);
        Task<int> AddAsync(T entity);

        bool Update(T entity);
        Task<bool> UpdateAsync(T entity);

        bool Delete(Guid id);
        Task<bool> DeleteAsync(Guid id);

        bool Delete(T entity);
        Task<bool> DeleteAsync(T entity);

        void Delete(Expression<Func<T, bool>> where, bool isHardDelete = false);
        Task AddRangeAsync(IEnumerable<T> entities);
        IQueryable<T> GetQuery();
        IQueryable<T> GetQuery(Expression<Func<T, bool>> where);
    }
}
