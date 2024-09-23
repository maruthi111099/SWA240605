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
            services.AddTransient<IDistrictRepository, DistrictRepository>();
            services.AddTransient<IPostRepository, PostRepository>();
            services.AddTransient<IPostUnitRepository, PostUnitRepository>();
            services.AddTransient<IUnionStateTerritoryRepository, UnionStateTerritoryRepository>();
            services.AddTransient<IVisitorRepository, VisitorRepository>();

            #endregion
        }
    }
}
