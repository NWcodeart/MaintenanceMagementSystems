using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MaintenanceManagementSystem.Database.Migrations
{
    public partial class FinalDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TemporaryPassword",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TemporaryPassword",
                table: "Users");
        }
    }
}
