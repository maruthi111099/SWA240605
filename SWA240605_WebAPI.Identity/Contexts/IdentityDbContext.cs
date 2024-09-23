using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SWA240605_WebAPI.Identity.Contexts.Configurations;
using SWA240605_WebAPI.Identity.Models;

namespace SWA240605_WebAPI.Identity.Contexts
{
    public class IdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration<ApplicationUser>(new UserConfiguration());

            builder.Entity<IdentityRole>(entity =>
            {
                entity.Property<string>(r => r.Name).IsRequired().HasMaxLength(30).HasColumnType("VARCHAR(30)");
                entity.Property<string>(r => r.NormalizedName).IsRequired().HasMaxLength(30).HasColumnType("VARCHAR(30)");

                entity.ToTable(name: "Roles");
            });

            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable(name: "UserRoles");
            });

            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable(name: "UserClaims");
            });

            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable(name: "UserLogins");
            });

            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims");
            });

            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens");
            });
        }
    }
}
