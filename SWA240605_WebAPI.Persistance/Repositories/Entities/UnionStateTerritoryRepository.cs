using SWA240605_WebAPI.Application.Interfaces;
using SWA240605_WebAPI.Application.Interfaces.Repositories;
using SWA240605_WebAPI.Domain.Entities;
using SWA240605_WebAPI.Persistance.Contexts;

namespace SWA240605_WebAPI.Persistance.Repositories.Entities
{
    public class UnionStateTerritoryRepository : GenericRepository<UnionStateTerritory> , IUnionStateTerritoryRepository
    {
        #region" constructor "

        public UnionStateTerritoryRepository(ApplicationDbContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork)
        { }

        #endregion
    }
}
