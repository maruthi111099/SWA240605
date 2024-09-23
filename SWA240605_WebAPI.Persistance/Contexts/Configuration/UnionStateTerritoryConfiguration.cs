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
    public class UnionStateTerritoryConfiguration : IEntityTypeConfiguration<UnionStateTerritory>
    {
        public void Configure(EntityTypeBuilder<UnionStateTerritory> builder)
        {
            builder.ToTable("UnionStateTerritories");

            builder.Property(ust => ust.Code).IsRequired().HasMaxLength(2).HasColumnType("VARCHAR(2)");
            builder.Property(ust => ust.Name).IsRequired().HasMaxLength(80).HasColumnType("VARCHAR(80)");
            builder.Property(ust => ust.OrderIndex).IsRequired();

            builder.HasKey(ust => ust.Code);
        }
    }
}
