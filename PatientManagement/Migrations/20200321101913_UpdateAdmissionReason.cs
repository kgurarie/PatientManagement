using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PatientManagement.Migrations
{
    public partial class UpdateAdmissionReason : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOn",
                table: "PatientAdmission",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "PatientAdmission",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "AdmissionReason",
                table: "PatientAdmission",
                type: "nvarchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOn",
                table: "PatientAdmission",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "PatientAdmission",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AdmissionReason",
                table: "PatientAdmission",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");
        }
    }
}
