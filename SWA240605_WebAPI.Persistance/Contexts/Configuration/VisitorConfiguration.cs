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
    public class VisitorConfiguration : IEntityTypeConfiguration<Visitor>
    {
        public void Configure(EntityTypeBuilder<Visitor> builder)
        {
            builder.ToTable("Visitors");

            builder.Property(v => v.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(v => v.IPAddress).IsRequired().HasMaxLength(50).HasColumnType("VARCHAR(50)");
            builder.Property(v => v.Browser).IsRequired().HasMaxLength(150).HasColumnType("VARCHAR(150)");
            builder.Property(v => v.Device).IsRequired().HasMaxLength(100).HasColumnType("VARCHAR(100)");
            builder.Property(v => v.VisitedOn).IsRequired();

            builder.HasKey(v => v.Id);
        }
    }
}
