using SWA240605_WebAPI.Application.Interfaces;
using SWA240605_WebAPI.Application.Interfaces.Repositories;
using SWA240605_WebAPI.Domain.Entities;
using SWA240605_WebAPI.Persistance.Contexts;

namespace SWA240605_WebAPI.Persistance.Repositories.Entities
{
    public class VisitorRepository : GenericRepository<Visitor> , IVisitorRepository
    {
        #region" constructor "

        public VisitorRepository(ApplicationDbContext dbContext , IUnitOfWork unitOfWork) : base(dbContext , unitOfWork) 
        { }

        #endregion
    }
}
