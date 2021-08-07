using Microsoft.EntityFrameworkCore.Migrations;

namespace MaintenanceManagementSystem.Database.Migrations
{
    public partial class addingBuildingManagerId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "buildingId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BuildingManagerId",
                table: "Buildings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_buildingId",
                table: "Users",
                column: "buildingId");

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_BuildingManagerId",
                table: "Buildings",
                column: "BuildingManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Buildings_Users_BuildingManagerId",
                table: "Buildings",
                column: "BuildingManagerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Buildings_buildingId",
                table: "Users",
                column: "buildingId",
                principalTable: "Buildings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buildings_Users_BuildingManagerId",
                table: "Buildings");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Buildings_buildingId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_buildingId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Buildings_BuildingManagerId",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "buildingId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BuildingManagerId",
                table: "Buildings");
        }
    }
}
