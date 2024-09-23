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
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Posts");

            builder.Property(p => p.Code).IsRequired().HasMaxLength(10).HasColumnType("VARCHAR(10)");
            builder.Property(p => p.Title_Eng).IsRequired().HasMaxLength(500).HasColumnType("VARCHAR(500)");
            builder.Property(p => p.Title_Lng).IsRequired().HasMaxLength(500).HasColumnType("VARCHAR(500)");
            builder.Property(p => p.NotificationNo_Eng).IsRequired().HasMaxLength(200).HasColumnType("VARCHAR(200)");
            builder.Property(p => p.NotificationNo_Lng).IsRequired().HasMaxLength(200).HasColumnType("VARCHAR(200)");
            builder.Property(p => p.Vacancy).IsRequired();
            builder.Property(p => p.ApplicationStartDate).IsRequired();
            builder.Property(p => p.ApplicationEndDate).IsRequired();
            builder.Property(p => p.ApplicationNoGenerationMode).IsRequired();

            builder.HasKey(p => p.Code);
        }
    }
}
