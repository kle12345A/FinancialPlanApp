using FinancialPlan.Entity.Entities.Base;
using FinancialPlan.Repository.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPlan.Service
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IBaseRepository<T> _baseRepository;

        public BaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _baseRepository = _unitOfWork.BaseRepository<T>();
        }

        public async Task<int> AddAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await _baseRepository.AddAsync(entity);
            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            if (entity == null)
                return false;

            _baseRepository.Update(entity);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var entity = await _baseRepository.GetByIdAsync(id);
                if (entity == null)
                    return false;

                _baseRepository.Delete(entity);
                await _unitOfWork.SaveChangesAsync(); // Lưu thay đổi xuống cơ sở dữ liệu

                return true; // Trả về true nếu xóa thành công và lưu thành công
            }
            catch (Exception ex)
            {
                // Log lỗi nếu có
                Console.WriteLine($"Error deleting entity: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            if (entity == null)
                return false;

            _baseRepository.Delete(entity);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _baseRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _baseRepository.GetAllAsync();
        }

        

        public bool Delete(Guid id)
        {
            var entity = _baseRepository.GetByIdAsync(id).Result;
            if (entity == null)
                return false;

            _baseRepository.Delete(entity);
            return _unitOfWork.SaveChangesAsync().Result > 0;
        }

        public async Task<int> AddRangeAsync(IEnumerable<T> entities)
        {
            if (entities == null || !entities.Any())
                throw new ArgumentNullException(nameof(entities));

            await _baseRepository.AddRangeAsync(entities);
            return await _unitOfWork.SaveChangesAsync();
        }



    }
}
