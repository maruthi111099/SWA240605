using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SWA240605_WebAPI.Domain.Entities;

namespace SWA240605_WebAPI.Persistance.Contexts.Configuration
{
    public class ApplicantPermanentAddressConfiguration : IEntityTypeConfiguration<ApplicantPermanentAddress>

    {
        public void Configure(EntityTypeBuilder<ApplicantPermanentAddress> builder)
        {
            builder.ToTable("ApplicantPermanentAddresses");

            builder.Property(apa => apa.ApplicationNo).IsRequired();
            builder.Property(apa => apa.DoorNo).IsRequired().HasMaxLength(15).HasColumnType("VARCHAR(15)");
            builder.Property(apa => apa.Street).IsRequired().HasMaxLength(60).HasColumnType("VARCHAR(60)");
            builder.Property(apa => apa.Landmark).IsRequired(false).HasMaxLength(60).HasColumnType("VARCHAR(60)");
            builder.Property(apa => apa.Taluk).IsRequired().HasMaxLength(80).HasColumnType("VARCHAR(80)");
            builder.Property(apa => apa.City).IsRequired().HasMaxLength(80).HasColumnType("VARCHAR(80)");
            builder.Property(apa => apa.DistrictCode).IsRequired().HasMaxLength(5).HasColumnType("VARCHAR(5)");
            builder.Property(apa => apa.OtherDistrictName).IsRequired(false).HasMaxLength(80).HasColumnType("VARCHAR(80)");
            builder.Property(apa => apa.UnionStateCode).IsRequired().HasMaxLength(2).HasColumnType("VARCHAR(2)");
            builder.Property(apa => apa.Pincode).IsRequired().HasMaxLength(6).HasColumnType("VARCHAR(6)");

            builder.HasKey(apa => apa.ApplicationNo);

            builder.HasOne(apa => apa.ApplicantContactAddresses)
                .WithOne(a => a.ApplicantPermanentAddresses)
                .HasForeignKey<ApplicantPermanentAddress>(apa => apa.ApplicationNo)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(apa => apa.Districts)
                .WithMany(d => d.ApplicantPermanentAddresses)
                .HasForeignKey(apa => apa.DistrictCode)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(apa => apa.UnionStateTerritories)
                .WithMany(ut => ut.ApplicantPermanentAddresses)
                .HasForeignKey(apa => apa.UnionStateCode)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
