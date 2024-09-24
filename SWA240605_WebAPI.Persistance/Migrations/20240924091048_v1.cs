using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SWA240605_WebAPI.Persistance.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Code = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false),
                    Title_Eng = table.Column<string>(type: "VARCHAR(500)", maxLength: 500, nullable: false),
                    Title_Lng = table.Column<string>(type: "VARCHAR(500)", maxLength: 500, nullable: false),
                    NotificationNo_Eng = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    NotificationNo_Lng = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    Vacancy = table.Column<int>(type: "int", nullable: false),
                    ApplicationStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApplicationEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApplicationNoGenerationMode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "UnionStateTerritories",
                columns: table => new
                {
                    Code = table.Column<string>(type: "VARCHAR(2)", maxLength: 2, nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    OrderIndex = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnionStateTerritories", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Visitors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IPAddress = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Browser = table.Column<string>(type: "VARCHAR(150)", maxLength: 150, nullable: false),
                    Device = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    VisitedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostUnits",
                columns: table => new
                {
                    Code = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false),
                    Title = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: false),
                    StartingApplicationNo = table.Column<int>(type: "int", nullable: false),
                    CurrentApplicationNo = table.Column<int>(type: "int", nullable: false),
                    EndApplicationNo = table.Column<int>(type: "int", nullable: false),
                    PostCode = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false),
                    OrderIndex = table.Column<int>(type: "int", nullable: false),
                    Vacancy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostUnits", x => x.Code);
                    table.ForeignKey(
                        name: "FK_PostUnits_Posts_PostCode",
                        column: x => x.PostCode,
                        principalTable: "Posts",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    Code = table.Column<string>(type: "VARCHAR(5)", maxLength: 5, nullable: false),
                    Title = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    UnionStateCode = table.Column<string>(type: "VARCHAR(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Districts_UnionStateTerritories_UnionStateCode",
                        column: x => x.UnionStateCode,
                        principalTable: "UnionStateTerritories",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Applicants",
                columns: table => new
                {
                    ApplicationNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "VARCHAR(120)", maxLength: 120, nullable: false),
                    FatherName = table.Column<string>(type: "VARCHAR(120)", maxLength: 120, nullable: false),
                    MotherName = table.Column<string>(type: "VARCHAR(120)", maxLength: 120, nullable: false),
                    MobileNo = table.Column<string>(type: "VARCHAR(12)", maxLength: 12, nullable: false),
                    EmailId = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    AadharNo = table.Column<string>(type: "VARCHAR(12)", maxLength: 12, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PostCode = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false),
                    PostUnitCode = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false),
                    VisitorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicants", x => x.ApplicationNo);
                    table.ForeignKey(
                        name: "FK_Applicants_Posts_PostCode",
                        column: x => x.PostCode,
                        principalTable: "Posts",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Applicants_PostUnits_PostUnitCode",
                        column: x => x.PostUnitCode,
                        principalTable: "PostUnits",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Applicants_Visitors_VisitorId",
                        column: x => x.VisitorId,
                        principalTable: "Visitors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicantContactAddresses",
                columns: table => new
                {
                    ApplicationNo = table.Column<int>(type: "int", nullable: false),
                    DoorNo = table.Column<string>(type: "VARCHAR(15)", maxLength: 15, nullable: false),
                    Street = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: false),
                    Landmark = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: true),
                    Taluk = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    City = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    DistrictCode = table.Column<string>(type: "VARCHAR(5)", maxLength: 5, nullable: false),
                    OtherDistrictName = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: true),
                    UnionStateCode = table.Column<string>(type: "VARCHAR(2)", maxLength: 2, nullable: false),
                    Pincode = table.Column<string>(type: "VARCHAR(6)", maxLength: 6, nullable: false),
                    IsPermanentAddressSame = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantContactAddresses", x => x.ApplicationNo);
                    table.ForeignKey(
                        name: "FK_ApplicantContactAddresses_Applicants_ApplicationNo",
                        column: x => x.ApplicationNo,
                        principalTable: "Applicants",
                        principalColumn: "ApplicationNo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApplicantContactAddresses_Districts_DistrictCode",
                        column: x => x.DistrictCode,
                        principalTable: "Districts",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApplicantContactAddresses_UnionStateTerritories_UnionStateCode",
                        column: x => x.UnionStateCode,
                        principalTable: "UnionStateTerritories",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ApplicantPermanentAddresses",
                columns: table => new
                {
                    ApplicationNo = table.Column<int>(type: "int", nullable: false),
                    DoorNo = table.Column<string>(type: "VARCHAR(15)", maxLength: 15, nullable: false),
                    Street = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: false),
                    Landmark = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: true),
                    Taluk = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    City = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    DistrictCode = table.Column<string>(type: "VARCHAR(5)", maxLength: 5, nullable: false),
                    OtherDistrictName = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: true),
                    UnionStateCode = table.Column<string>(type: "VARCHAR(2)", maxLength: 2, nullable: false),
                    Pincode = table.Column<string>(type: "VARCHAR(6)", maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantPermanentAddresses", x => x.ApplicationNo);
                    table.ForeignKey(
                        name: "FK_ApplicantPermanentAddresses_ApplicantContactAddresses_ApplicationNo",
                        column: x => x.ApplicationNo,
                        principalTable: "ApplicantContactAddresses",
                        principalColumn: "ApplicationNo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApplicantPermanentAddresses_Districts_DistrictCode",
                        column: x => x.DistrictCode,
                        principalTable: "Districts",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApplicantPermanentAddresses_UnionStateTerritories_UnionStateCode",
                        column: x => x.UnionStateCode,
                        principalTable: "UnionStateTerritories",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantContactAddresses_DistrictCode",
                table: "ApplicantContactAddresses",
                column: "DistrictCode");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantContactAddresses_UnionStateCode",
                table: "ApplicantContactAddresses",
                column: "UnionStateCode");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantPermanentAddresses_DistrictCode",
                table: "ApplicantPermanentAddresses",
                column: "DistrictCode");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantPermanentAddresses_UnionStateCode",
                table: "ApplicantPermanentAddresses",
                column: "UnionStateCode");

            migrationBuilder.CreateIndex(
                name: "IX_Applicants_PostCode",
                table: "Applicants",
                column: "PostCode");

            migrationBuilder.CreateIndex(
                name: "IX_Applicants_PostUnitCode",
                table: "Applicants",
                column: "PostUnitCode");

            migrationBuilder.CreateIndex(
                name: "IX_Applicants_VisitorId",
                table: "Applicants",
                column: "VisitorId");

            migrationBuilder.CreateIndex(
                name: "IX_Districts_UnionStateCode",
                table: "Districts",
                column: "UnionStateCode");

            migrationBuilder.CreateIndex(
                name: "IX_PostUnits_PostCode",
                table: "PostUnits",
                column: "PostCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicantPermanentAddresses");

            migrationBuilder.DropTable(
                name: "ApplicantContactAddresses");

            migrationBuilder.DropTable(
                name: "Applicants");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "PostUnits");

            migrationBuilder.DropTable(
                name: "Visitors");

            migrationBuilder.DropTable(
                name: "UnionStateTerritories");

            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
