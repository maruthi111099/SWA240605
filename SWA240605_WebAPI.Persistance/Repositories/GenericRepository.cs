using Microsoft.EntityFrameworkCore;
using SWA240605_WebAPI.Application.Interfaces;
using SWA240605_WebAPI.Persistance.Contexts;
using System.Linq.Expressions;

namespace SWA240605_WebAPI.Persistance.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _dbContext;
        private readonly DbSet<T> _dbSet;
        private readonly IUnitOfWork _unitOfWork;

        public GenericRepository(ApplicationDbContext dbContext, IUnitOfWork unitOfWork)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
            _unitOfWork = unitOfWork;
        }

        //public virtual async Task<T> GetByIdAsync(object id, params Expression<Func<T, object>>[] includes)
        //{
        //    return await includes.ToList().ForEach(x => _dbContext.Set<T>().Include(x).Load());
        //}

        public virtual async Task<T?> GetByIdAsync(object id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> GetPagedResponseAsync(int pageNumber, int pageSize)
        {
            return await _dbContext
                .Set<T>()
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<T?> GetAsync(Expression<Func<T, bool>> criteria)
        {
            return await _dbContext.Set<T>().Where(criteria).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> GetManyAsync(Expression<Func<T, bool>> criteria)
        {
            return await _dbContext.Set<T>().Where(criteria).ToListAsync();
        }

        public void AddRange(List<T> entities)
        {
            _dbContext.Set<T>().AddRange(entities);
        }

        public void Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().RemoveRange(entities);
        }

        public async Task<int> CommitAsync()
        {
            return await _unitOfWork.CommitAsync();
        }

        public async Task RollbackAsync()
        {
            await _dbContext.RefreshAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbContext
                 .Set<T>()
                 .ToListAsync();
        }
    }
}
