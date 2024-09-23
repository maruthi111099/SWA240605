using SWA240605_WebAPI.Application.Interfaces;
using SWA240605_WebAPI.Application.Interfaces.Repositories;
using SWA240605_WebAPI.Domain.Entities;
using SWA240605_WebAPI.Persistance.Contexts;

namespace SWA240605_WebAPI.Persistance.Repositories.Entities
{
    public class ApplicantRepository : GenericRepository<Applicant>, IApplicantRepository
    {
        #region " constructor "

        public ApplicantRepository(ApplicationDbContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        { }

        #endregion
    }
}
