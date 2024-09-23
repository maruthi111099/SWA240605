using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SWA240605_WebAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWA240605_WebAPI.Persistance.Contexts.Configuration
{
    public class ApplicantConfiguration : IEntityTypeConfiguration<Applicant>
    {
        public void Configure(EntityTypeBuilder<Applicant> builder)
        {
            builder.ToTable("Applicants");

            builder.Property(a => a.ApplicationNo).IsRequired();
            builder.Property(a => a.FullName).IsRequired().HasMaxLength(120).HasColumnType("VARCHAR(120)");
            builder.Property(a => a.FatherName).IsRequired().HasMaxLength(120).HasColumnType("VARCHAR(120)");
            builder.Property(a => a.MotherName).IsRequired().HasMaxLength(120).HasColumnType("VARCHAR(120)");
            builder.Property(a => a.MobileNo).IsRequired().HasMaxLength(12).HasColumnType("VARCHAR(12)");
            builder.Property(a => a.EmailId).IsRequired().HasMaxLength(80).HasColumnType("VARCHAR(80)");
            builder.Property(a => a.AadharNo).IsRequired().HasMaxLength(12).HasColumnType("VARCHAR(12)");
            builder.Property(a => a.DateOfBirth).IsRequired();
            builder.Property(a => a.PostCode).IsRequired().HasMaxLength(10).HasColumnType("VARCHAR(10)");
            builder.Property(a => a.PostUnitCode).IsRequired().HasMaxLength(10).HasColumnType("VARCHAR(10)");
            builder.Property(a => a.VisitorId).IsRequired();

            builder.HasKey(a => a.ApplicationNo);

            builder.HasOne(a => a.Posts)
                .WithMany(a => a.Applicants)
                .HasForeignKey(a => a.PostCode)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.PostsUnit)
               .WithMany(a => a.Applicants)
               .HasForeignKey(a => a.PostUnitCode)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Visitors)
                .WithMany(a => a.Applicants)
                .HasForeignKey(a => a.VisitorId);
        }
    }
}
