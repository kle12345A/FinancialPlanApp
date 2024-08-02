using FinancialPlan.Entity.Contexts;
using FinancialPlan.Entity.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPlan.Repository.Infrastructures
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, IBaseEntity
    {
        protected readonly FinancialPlanDbContext dataContext;
        protected DbSet<T> dbSet;

        public BaseRepository(FinancialPlanDbContext context)
        {
            dataContext = context;
            dbSet = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.AsNoTracking().ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbSet.AsNoTracking().ToListAsync();
        }

        public T GetById(Guid id)
        {
            return dbSet.Find(id);
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public int Add(T entity)
        {
            dbSet.Add(entity);
            return dataContext.SaveChanges();
        }

        public async Task<int> AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            return await dataContext.SaveChangesAsync();
        }

        public bool Update(T entity)
        {
            dbSet.Update(entity);
            return dataContext.SaveChanges() > 0;
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            dbSet.Update(entity);
            return await dataContext.SaveChangesAsync() > 0;
        }

        public bool Delete(Guid id)
        {
            var entity = dbSet.Find(id);
            if (entity == null) return false;

            dbSet.Remove(entity);
            return dataContext.SaveChanges() > 0;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await dbSet.FindAsync(id);
            if (entity == null) return false;

            dbSet.Remove(entity);
            return await dataContext.SaveChangesAsync() > 0;
        }

        public bool Delete(T entity)
        {
            if (entity == null) return false;

            dbSet.Remove(entity);
            return dataContext.SaveChanges() > 0;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            if (entity == null) return false;

            dbSet.Remove(entity);
            return await dataContext.SaveChangesAsync() > 0;
        }

        public void Delete(Expression<Func<T, bool>> where, bool isHardDelete = false)
        {
            var entities = dbSet.Where(where).ToList();
            dbSet.RemoveRange(entities);
            dataContext.SaveChanges();
        }

        public IQueryable<T> GetQuery()
        {
            return dbSet.AsQueryable();
        }

        public IQueryable<T> GetQuery(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await dbSet.AddRangeAsync(entities);
            await dataContext.SaveChangesAsync();
        }
    }
}
