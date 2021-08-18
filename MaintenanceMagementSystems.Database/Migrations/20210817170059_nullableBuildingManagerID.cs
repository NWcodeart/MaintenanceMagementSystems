using Microsoft.EntityFrameworkCore.Migrations;

namespace MaintenanceManagementSystem.Database.Migrations
{
    public partial class nullableBuildingManagerID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buildings_Users_BuildingManagerId",
                table: "Buildings");

            migrationBuilder.AlterColumn<int>(
                name: "BuildingManagerId",
                table: "Buildings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Buildings_Users_BuildingManagerId",
                table: "Buildings",
                column: "BuildingManagerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buildings_Users_BuildingManagerId",
                table: "Buildings");

            migrationBuilder.AlterColumn<int>(
                name: "BuildingManagerId",
                table: "Buildings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Buildings_Users_BuildingManagerId",
                table: "Buildings",
                column: "BuildingManagerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
