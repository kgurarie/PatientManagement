using Microsoft.EntityFrameworkCore.Migrations;

namespace PatientManagement.Migrations
{
    public partial class PopulateStates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into State ( Name, Code) values('New South Wales','NSW')");
            migrationBuilder.Sql("insert into State (Name, Code) values('Queensland','QLD')");
            migrationBuilder.Sql("insert into State (Name, Code) values('South Australia','SA')");
            migrationBuilder.Sql("insert into State (Name, Code) values('Tasmania','TAS')");
            migrationBuilder.Sql("insert into State (Name, Code) values('Victoria','VIC')");
            migrationBuilder.Sql("insert into State (Name, Code) values('Western Australia','WA')");
            migrationBuilder.Sql("insert into State (Name, Code) values('Australian Capital Territory','ACT')");
            migrationBuilder.Sql("insert into State (Name, Code) values('Northern Territory','NT')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from State");
        }
    }
}
