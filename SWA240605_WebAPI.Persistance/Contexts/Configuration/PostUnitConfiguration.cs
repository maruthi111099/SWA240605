using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SWA240605_WebAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWA240605_WebAPI.Persistance.Contexts.Configuration
{
    public class PostUnitConfiguration : IEntityTypeConfiguration<PostUnit>
    {
        public void Configure(EntityTypeBuilder<PostUnit> builder)
        {
            builder.ToTable("PostUnits");

            builder.Property(pu => pu.Code).IsRequired().HasMaxLength(10).HasColumnType("VARCHAR(10)");
            builder.Property(pu => pu.Title).IsRequired().HasMaxLength(60).HasColumnType("VARCHAR(60)");
            builder.Property(pu => pu.StartingApplicationNo).IsRequired();
            builder.Property(pu => pu.CurrentApplicationNo).IsRequired();
            builder.Property(pu => pu.EndApplicationNo).IsRequired();
            builder.Property(pu => pu.PostCode).IsRequired().HasMaxLength(10).HasColumnType("VARCHAR(10)");
            builder.Property(pu => pu.OrderIndex).IsRequired();
            builder.Property(pu => pu.Vacancy).IsRequired();

            builder.HasKey(pu => pu.Code);

            builder.HasOne(pu => pu.Posts)
                .WithMany(p => p.PostUnits)
                .HasForeignKey(pu => pu.PostCode)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
