using Microsoft.EntityFrameworkCore;
using SWA240605_WebAPI.Application.Interfaces;
using SWA240605_WebAPI.Application.Interfaces.Repositories;
using SWA240605_WebAPI.Domain.Entities;
using SWA240605_WebAPI.Persistance.Contexts;

namespace SWA240605_WebAPI.Persistance.Repositories.Entities
{
    public class DistrictRepository : GenericRepository<District>, IDistrictRepository
    {
        #region" constructor "

        public DistrictRepository(ApplicationDbContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork)
        { }

        #endregion
    }
}
