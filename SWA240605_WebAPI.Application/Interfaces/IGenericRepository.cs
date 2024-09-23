using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SWA240605_WebAPI.Application.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(object id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetPagedResponseAsync(int pageNumber, int pageSize);
        Task<T?> GetAsync(Expression<Func<T, bool>> criteria);
        Task<IReadOnlyList<T>> GetManyAsync(Expression<Func<T, bool>> criteria);
        void AddRange(List<T> entities);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void RemoveRange(IEnumerable<T> entities);
        Task<int> CommitAsync();
        Task RollbackAsync();
    }
}
