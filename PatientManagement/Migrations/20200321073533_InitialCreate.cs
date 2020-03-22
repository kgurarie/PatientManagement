using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PatientManagement.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    StreetAddress = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    PostCode = table.Column<int>(nullable: false),
                    StateId = table.Column<int>(nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    EmergencyContactName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    EmergencyContactPhone = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(20)", nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(type: "varchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patient_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientAdmission",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(nullable: false),
                    AdmissionReason = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(20)", nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(type: "varchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientAdmission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientAdmission_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patient_StateId",
                table: "Patient",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientAdmission_PatientId",
                table: "PatientAdmission",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientAdmission");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "State");
        }
    }
}
