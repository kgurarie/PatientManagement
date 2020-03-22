using Microsoft.EntityFrameworkCore.Migrations;

namespace PatientManagement.Migrations
{
    public partial class UpdatePatientContact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EmergencyContactPhone",
                table: "Patient",
                type: "nvarchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)");

            migrationBuilder.AlterColumn<string>(
                name: "EmergencyContactName",
                table: "Patient",
                type: "nvarchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EmergencyContactPhone",
                table: "Patient",
                type: "nvarchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmergencyContactName",
                table: "Patient",
                type: "nvarchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldNullable: true);
        }
    }
}
