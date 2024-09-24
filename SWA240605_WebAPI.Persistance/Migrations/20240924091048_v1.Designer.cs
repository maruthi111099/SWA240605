﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SWA240605_WebAPI.Persistance.Contexts;

#nullable disable

namespace SWA240605_WebAPI.Persistance.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240924091048_v1")]
    partial class v1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SWA240605_WebAPI.Domain.Entities.Applicant", b =>
                {
                    b.Property<int>("ApplicationNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ApplicationNo"), 1L, 1);

                    b.Property<string>("AadharNo")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("VARCHAR(12)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailId")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("VARCHAR(80)");

                    b.Property<string>("FatherName")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("VARCHAR(120)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("VARCHAR(120)");

                    b.Property<string>("MobileNo")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("VARCHAR(12)");

                    b.Property<string>("MotherName")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("VARCHAR(120)");

                    b.Property<string>("PostCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("VARCHAR(10)");

                    b.Property<string>("PostUnitCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("VARCHAR(10)");

                    b.Property<int>("VisitorId")
                        .HasColumnType("int");

                    b.HasKey("ApplicationNo");

                    b.HasIndex("PostCode");

                    b.HasIndex("PostUnitCode");

                    b.HasIndex("VisitorId");

                    b.ToTable("Applicants", (string)null);
                });

            modelBuilder.Entity("SWA240605_WebAPI.Domain.Entities.ApplicantContactAddress", b =>
                {
                    b.Property<int>("ApplicationNo")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("VARCHAR(80)");

                    b.Property<string>("DistrictCode")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("VARCHAR(5)");

                    b.Property<string>("DoorNo")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("VARCHAR(15)");

                    b.Property<bool>("IsPermanentAddressSame")
                        .HasColumnType("bit");

                    b.Property<string>("Landmark")
                        .HasMaxLength(60)
                        .HasColumnType("VARCHAR(60)");

                    b.Property<string>("OtherDistrictName")
                        .HasMaxLength(80)
                        .HasColumnType("VARCHAR(80)");

                    b.Property<string>("Pincode")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("VARCHAR(6)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("VARCHAR(60)");

                    b.Property<string>("Taluk")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("VARCHAR(80)");

                    b.Property<string>("UnionStateCode")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("VARCHAR(2)");

                    b.HasKey("ApplicationNo");

                    b.HasIndex("DistrictCode");

                    b.HasIndex("UnionStateCode");

                    b.ToTable("ApplicantContactAddresses", (string)null);
                });

            modelBuilder.Entity("SWA240605_WebAPI.Domain.Entities.ApplicantPermanentAddress", b =>
                {
                    b.Property<int>("ApplicationNo")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("VARCHAR(80)");

                    b.Property<string>("DistrictCode")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("VARCHAR(5)");

                    b.Property<string>("DoorNo")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("VARCHAR(15)");

                    b.Property<string>("Landmark")
                        .HasMaxLength(60)
                        .HasColumnType("VARCHAR(60)");

                    b.Property<string>("OtherDistrictName")
                        .HasMaxLength(80)
                        .HasColumnType("VARCHAR(80)");

                    b.Property<string>("Pincode")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("VARCHAR(6)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("VARCHAR(60)");

                    b.Property<string>("Taluk")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("VARCHAR(80)");

                    b.Property<string>("UnionStateCode")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("VARCHAR(2)");

                    b.HasKey("ApplicationNo");

                    b.HasIndex("DistrictCode");

                    b.HasIndex("UnionStateCode");

                    b.ToTable("ApplicantPermanentAddresses", (string)null);
                });

            modelBuilder.Entity("SWA240605_WebAPI.Domain.Entities.District", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(5)
                        .HasColumnType("VARCHAR(5)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("VARCHAR(80)");

                    b.Property<string>("UnionStateCode")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("VARCHAR(2)");

                    b.HasKey("Code");

                    b.HasIndex("UnionStateCode");

                    b.ToTable("Districts", (string)null);
                });

            modelBuilder.Entity("SWA240605_WebAPI.Domain.Entities.Post", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(10)
                        .HasColumnType("VARCHAR(10)");

                    b.Property<DateTime>("ApplicationEndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ApplicationNoGenerationMode")
                        .HasColumnType("int");

                    b.Property<DateTime>("ApplicationStartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NotificationNo_Eng")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("VARCHAR(200)");

                    b.Property<string>("NotificationNo_Lng")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("VARCHAR(200)");

                    b.Property<string>("Title_Eng")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("VARCHAR(500)");

                    b.Property<string>("Title_Lng")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("VARCHAR(500)");

                    b.Property<int>("Vacancy")
                        .HasColumnType("int");

                    b.HasKey("Code");

                    b.ToTable("Posts", (string)null);
                });

            modelBuilder.Entity("SWA240605_WebAPI.Domain.Entities.PostUnit", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(10)
                        .HasColumnType("VARCHAR(10)");

                    b.Property<int>("CurrentApplicationNo")
                        .HasColumnType("int");

                    b.Property<int>("EndApplicationNo")
                        .HasColumnType("int");

                    b.Property<int>("OrderIndex")
                        .HasColumnType("int");

                    b.Property<string>("PostCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("VARCHAR(10)");

                    b.Property<int>("StartingApplicationNo")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("VARCHAR(60)");

                    b.Property<int>("Vacancy")
                        .HasColumnType("int");

                    b.HasKey("Code");

                    b.HasIndex("PostCode");

                    b.ToTable("PostUnits", (string)null);
                });

            modelBuilder.Entity("SWA240605_WebAPI.Domain.Entities.UnionStateTerritory", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(2)
                        .HasColumnType("VARCHAR(2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("VARCHAR(80)");

                    b.Property<int>("OrderIndex")
                        .HasColumnType("int");

                    b.HasKey("Code");

                    b.ToTable("UnionStateTerritories", (string)null);
                });

            modelBuilder.Entity("SWA240605_WebAPI.Domain.Entities.Visitor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Browser")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("VARCHAR(150)");

                    b.Property<string>("Device")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("IPAddress")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR(50)");

                    b.Property<DateTime>("VisitedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Visitors", (string)null);
                });

            modelBuilder.Entity("SWA240605_WebAPI.Domain.Entities.Applicant", b =>
                {
                    b.HasOne("SWA240605_WebAPI.Domain.Entities.Post", "Posts")
                        .WithMany("Applicants")
                        .HasForeignKey("PostCode")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SWA240605_WebAPI.Domain.Entities.PostUnit", "PostsUnit")
                        .WithMany("Applicants")
                        .HasForeignKey("PostUnitCode")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SWA240605_WebAPI.Domain.Entities.Visitor", "Visitors")
                        .WithMany("Applicants")
                        .HasForeignKey("VisitorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Posts");

                    b.Navigation("PostsUnit");

                    b.Navigation("Visitors");
                });

            modelBuilder.Entity("SWA240605_WebAPI.Domain.Entities.ApplicantContactAddress", b =>
                {
                    b.HasOne("SWA240605_WebAPI.Domain.Entities.Applicant", "Applicants")
                        .WithOne("ApplicantContactAddresses")
                        .HasForeignKey("SWA240605_WebAPI.Domain.Entities.ApplicantContactAddress", "ApplicationNo")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SWA240605_WebAPI.Domain.Entities.District", "Districts")
                        .WithMany("ApplicantContactAddresses")
                        .HasForeignKey("DistrictCode")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SWA240605_WebAPI.Domain.Entities.UnionStateTerritory", "UnionStateTerritories")
                        .WithMany("ApplicantContactAddresses")
                        .HasForeignKey("UnionStateCode")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Applicants");

                    b.Navigation("Districts");

                    b.Navigation("UnionStateTerritories");
                });

            modelBuilder.Entity("SWA240605_WebAPI.Domain.Entities.ApplicantPermanentAddress", b =>
                {
                    b.HasOne("SWA240605_WebAPI.Domain.Entities.ApplicantContactAddress", "ApplicantContactAddresses")
                        .WithOne("ApplicantPermanentAddresses")
                        .HasForeignKey("SWA240605_WebAPI.Domain.Entities.ApplicantPermanentAddress", "ApplicationNo")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SWA240605_WebAPI.Domain.Entities.District", "Districts")
                        .WithMany("ApplicantPermanentAddresses")
                        .HasForeignKey("DistrictCode")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SWA240605_WebAPI.Domain.Entities.UnionStateTerritory", "UnionStateTerritories")
                        .WithMany("ApplicantPermanentAddresses")
                        .HasForeignKey("UnionStateCode")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ApplicantContactAddresses");

                    b.Navigation("Districts");

                    b.Navigation("UnionStateTerritories");
                });

            modelBuilder.Entity("SWA240605_WebAPI.Domain.Entities.District", b =>
                {
                    b.HasOne("SWA240605_WebAPI.Domain.Entities.UnionStateTerritory", "UnionStateTerritories")
                        .WithMany("Districts")
                        .HasForeignKey("UnionStateCode")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("UnionStateTerritories");
                });

            modelBuilder.Entity("SWA240605_WebAPI.Domain.Entities.PostUnit", b =>
                {
                    b.HasOne("SWA240605_WebAPI.Domain.Entities.Post", "Posts")
                        .WithMany("PostUnits")
                        .HasForeignKey("PostCode")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Posts");
                });

            modelBuilder.Entity("SWA240605_WebAPI.Domain.Entities.Applicant", b =>
                {
                    b.Navigation("ApplicantContactAddresses");
                });

            modelBuilder.Entity("SWA240605_WebAPI.Domain.Entities.ApplicantContactAddress", b =>
                {
                    b.Navigation("ApplicantPermanentAddresses");
                });

            modelBuilder.Entity("SWA240605_WebAPI.Domain.Entities.District", b =>
                {
                    b.Navigation("ApplicantContactAddresses");

                    b.Navigation("ApplicantPermanentAddresses");
                });

            modelBuilder.Entity("SWA240605_WebAPI.Domain.Entities.Post", b =>
                {
                    b.Navigation("Applicants");

                    b.Navigation("PostUnits");
                });

            modelBuilder.Entity("SWA240605_WebAPI.Domain.Entities.PostUnit", b =>
                {
                    b.Navigation("Applicants");
                });

            modelBuilder.Entity("SWA240605_WebAPI.Domain.Entities.UnionStateTerritory", b =>
                {
                    b.Navigation("ApplicantContactAddresses");

                    b.Navigation("ApplicantPermanentAddresses");

                    b.Navigation("Districts");
                });

            modelBuilder.Entity("SWA240605_WebAPI.Domain.Entities.Visitor", b =>
                {
                    b.Navigation("Applicants");
                });
#pragma warning restore 612, 618
        }
    }
}
