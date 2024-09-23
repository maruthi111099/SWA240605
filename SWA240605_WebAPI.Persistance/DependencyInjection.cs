using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SWA240605_WebAPI.Application.Interfaces;
using SWA240605_WebAPI.Application.Interfaces.Repositories;
using SWA240605_WebAPI.Persistance.Contexts;
using SWA240605_WebAPI.Persistance.Repositories;
using SWA240605_WebAPI.Persistance.Repositories.Entities;

namespace SWA240605_WebAPI.Persistance
{
    public static class DependencyInjection
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            #region " db context "

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            #endregion

            #region " repositories "

            //
            // generals
            //
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            //
            // entities
            //
            services.AddTransient<IApplicantRepository, ApplicantRepository>();
            services.AddTransient<IApplicantDownloadRepository, ApplicantDownloadRepository>();
            services.AddTransient<IApplicantEligibilityStatusRepository, ApplicantEligibilityStatusRepository>();
            services.AddTransient<IApplicantUploadRepository, ApplicantUploadRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IDistrictRepository, DistrictRepository>();
            services.AddTransient<IDocumentTypeRepository, DocumentTypeRepository>();
            services.AddTransient<IGenderRepository, GenderRepository>();
            services.AddTransient<IIdentityCardTypeRepository, IdentityCardTypeRepository>();
            services.AddTransient<IKannadaStudiedModeRepository, KannadaStudiedModeRepository>();
            services.AddTransient<IPostHomePageContentRepository, PostHomePageContentRepository>();
            services.AddTransient<IPostMenuRepository, PostMenuRepository>();
            services.AddTransient<IPostNewsEventDocumentRepository, PostNewsEventDocumentRepository>();
            services.AddTransient<IPostNewsEventRepository, PostNewsEventRepository>();
            services.AddTransient<IPostRepository, PostRepository>();
            services.AddTransient<IPostUnitRepository, PostUnitRepository>();
            services.AddTransient<IPostUnitQualificationRepository, PostUnitQualificationRepository>();
            services.AddTransient<IQualificationBoardRepository, QualificationBoardRepository>();
            services.AddTransient<IRecruitmentActivityRepository, RecruitmentActivityRepository>();
            services.AddTransient<IUnionStateTerritoryRepository, UnionStateTerritoryRepository>();
            services.AddTransient<IVisitorRepository, VisitorRepository>();

            #endregion
        }
    }
}
