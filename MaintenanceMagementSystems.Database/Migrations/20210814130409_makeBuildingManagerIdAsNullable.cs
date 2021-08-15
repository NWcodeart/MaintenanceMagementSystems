using Microsoft.EntityFrameworkCore.Migrations;

namespace MaintenanceManagementSystem.Database.Migrations
{
    public partial class makeBuildingManagerIdAsNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "BuildingManagerId",
                table: "Buildings",
                type: "int",
                nullable: true
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
