using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PatientManagement.Migrations
{
    public partial class UpdatePatient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOn",
                table: "Patient",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Suburb",
                table: "Patient",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Suburb",
                table: "Patient");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOn",
                table: "Patient",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
