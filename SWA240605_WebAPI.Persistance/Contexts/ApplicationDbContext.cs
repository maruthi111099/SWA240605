using Microsoft.EntityFrameworkCore;
using SWA240605_WebAPI.Application.Interfaces;
using SWA240605_WebAPI.Domain.Entities.Base;

namespace SWA240605_WebAPI.Persistance.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IDateTimeService? _dateTime;
        private readonly IAuthenticatedUserService? _authenticatedUser;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDateTimeService dateTime, IAuthenticatedUserService authenticatedUser) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _dateTime = dateTime;
            _authenticatedUser = authenticatedUser;
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<BaseAuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:

                        if (_dateTime == null || _authenticatedUser == null) throw new Exception();

                        entry.Entity.CreatedOn = _dateTime.NowUTC;
                        entry.Entity.CreatedBy = _authenticatedUser.UserCode == null ? string.Empty : _authenticatedUser.UserCode;

                        break;

                    case EntityState.Modified:

                        if (_dateTime == null || _authenticatedUser == null) throw new Exception();

                        entry.Entity.LastModifiedOn = _dateTime.NowUTC;
                        entry.Entity.LastModifiedBy = _authenticatedUser.UserCode == null ? string.Empty : _authenticatedUser.UserCode;

                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        public Task RefreshAsync()
        {
            foreach (var entry in ChangeTracker.Entries().ToList())
            {
                entry.State = EntityState.Detached;
            }
            return Task.FromResult(0);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // All Decimal will have 18,6 Range
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                                                    .SelectMany(t => t.GetProperties())
                                                    .Where(p => p.ClrType == typeof(decimal) ||
                                                                p.ClrType == typeof(decimal?)))
            {
                property.SetColumnType("decimal(18,6)");
            }
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                                                       .SelectMany(t => t.GetProperties())
                                                       .Where(p => p.ClrType == typeof(string) && // entity is string
                                                                   p.GetColumnType() == null)     // no column type defined
                    )
            {
                property.SetIsUnicode(false);
            }
            base.OnModelCreating(modelBuilder);
        }
    }
}
