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
    public class DistrictConfiguration : IEntityTypeConfiguration<District>
    {
        public void Configure(EntityTypeBuilder<District> builder)
        {
            builder.ToTable("Districts");

            builder.Property(d => d.Code).IsRequired().HasMaxLength(5).HasColumnType("VARCHAR(5)");
            builder.Property(d => d.Title).IsRequired().HasMaxLength(80).HasColumnType("VARCHAR(80)");
            builder.Property(d => d.UnionStateCode).IsRequired().HasMaxLength(2).HasColumnType("VARCHAR(2)");

            builder.HasKey(d => d.Code);

            builder.HasOne(d => d.UnionStateTerritories)
                .WithMany(us => us.Districts)
                .HasForeignKey(d => d.UnionStateCode)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
