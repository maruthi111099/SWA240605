using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SWA240605_WebAPI.Identity.Models;

namespace SWA240605_WebAPI.Identity.Contexts.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.ToTable("Users");

            builder.Property(u => u.Name).IsRequired().HasMaxLength(80).HasColumnType("VARCHAR(80)");
            builder.Property(u => u.UserName).IsRequired().HasMaxLength(30).HasColumnType("VARCHAR(30)");
            builder.Property(u => u.PhoneNumber).IsRequired(false);
            builder.Property(u => u.Email).IsRequired(false);

            builder.HasIndex(u => u.PhoneNumber).IsUnique(false);
            builder.HasIndex(u => u.Email).IsUnique(false);
        }
    }
}
