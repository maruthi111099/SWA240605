using SWA240605_WebAPI.Application.Interfaces;
using SWA240605_WebAPI.Persistance.Contexts;

namespace SWA240605_WebAPI.Persistance.Repositories
{
    public class UnitOfWork : IUnitOfWork

    {
        private readonly ApplicationDbContext _dbContext;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<int> CommitAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public async Task RefreshAsync()
        {
            await _dbContext.RefreshAsync();
        }
    }
}
