using Microsoft.EntityFrameworkCore.Migrations;

namespace MaintenanceManagementSystem.Database.Migrations
{
    public partial class removeJobType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_JobTypes_JobTypeId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "JobTypes");

            migrationBuilder.DropIndex(
                name: "IX_Users_JobTypeId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "JobTypeId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "UserRoles",
                newName: "RoleType");

            migrationBuilder.AddColumn<string>(
                name: "RoleNameAr",
                table: "UserRoles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RoleNameEn",
                table: "UserRoles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoleNameAr",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "RoleNameEn",
                table: "UserRoles");

            migrationBuilder.RenameColumn(
                name: "RoleType",
                table: "UserRoles",
                newName: "Role");

            migrationBuilder.AddColumn<int>(
                name: "JobTypeId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "JobTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobTypeNameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobTypeNameEn = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_JobTypeId",
                table: "Users",
                column: "JobTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_JobTypes_JobTypeId",
                table: "Users",
                column: "JobTypeId",
                principalTable: "JobTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
