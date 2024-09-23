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
    public class ApplicantContactAddressConfiguration : IEntityTypeConfiguration<ApplicantContactAddress>
    {
        public void Configure(EntityTypeBuilder<ApplicantContactAddress> builder)
        {
            builder.ToTable("ApplicantContactAddresses");

            builder.Property(aca => aca.ApplicationNo).IsRequired();
            builder.Property(aca => aca.DoorNo).IsRequired().HasMaxLength(15).HasColumnType("VARCHAR(15)");
            builder.Property(aca => aca.Street).IsRequired().HasMaxLength(60).HasColumnType("VARCHAR(60)");
            builder.Property(aca => aca.Landmark).IsRequired(false).HasMaxLength(60).HasColumnType("VARCHAR(60)");
            builder.Property(aca => aca.Taluk).IsRequired().HasMaxLength(80).HasColumnType("VARCHAR(80)");
            builder.Property(aca => aca.City).IsRequired().HasMaxLength(80).HasColumnType("VARCHAR(80)");
            builder.Property(aca => aca.DistrictCode).IsRequired().HasMaxLength(5).HasColumnType("VARCHAR(5)");
            builder.Property(aca => aca.OtherDistrictName).IsRequired(false).HasMaxLength(80).HasColumnType("VARCHAR(80)");
            builder.Property(aca => aca.UnionStateCode).IsRequired().HasMaxLength(2).HasColumnType("VARCHAR(2)");
            builder.Property(aca => aca.Pincode).IsRequired().HasMaxLength(6).HasColumnType("VARCHAR(6)");
            builder.Property(aca => aca.IsPermanentAddressSame).IsRequired();

            builder.HasKey(aca => aca.ApplicationNo);

            builder.HasOne(aca => aca.Applicants)
                .WithOne(a => a.ApplicantContactAddresses)
                .HasForeignKey<ApplicantContactAddress>(aca => aca.ApplicationNo)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(aca => aca.Districts)
                .WithMany(d => d.ApplicantContactAddresses)
                .HasForeignKey(aca => aca.DistrictCode)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(aca => aca.UnionStateTerritories)
                .WithMany(us => us.ApplicantContactAddresses)
                .HasForeignKey(aca => aca.UnionStateCode)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
