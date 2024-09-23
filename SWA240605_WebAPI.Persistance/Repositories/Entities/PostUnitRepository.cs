using SWA240605_WebAPI.Application.Interfaces.Repositories;
using SWA240605_WebAPI.Application.Interfaces;
using SWA240605_WebAPI.Domain.Entities;
using SWA240605_WebAPI.Persistance.Contexts;

namespace SWA240605_WebAPI.Persistance.Repositories.Entities
{
    public class PostUnitRepository : GenericRepository<PostUnit>, IPostUnitRepository
    {
        #region" constructor "

        public PostUnitRepository(ApplicationDbContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork)
        { }

        #endregion
    }
}


