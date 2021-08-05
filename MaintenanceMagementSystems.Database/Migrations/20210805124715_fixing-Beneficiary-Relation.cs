using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MaintenanceManagementSystem.Database.Migrations
{
    public partial class fixingBeneficiaryRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buildings_Countries_CountryId",
                table: "Buildings");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Users_BeneficiaryID",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Tickets_BeneficiaryTicketId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_BeneficiaryTicketId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Buildings_CountryId",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "BeneficiaryTicketId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Buildings");

            migrationBuilder.RenameColumn(
                name: "ForgetPassword",
                table: "Users",
                newName: "IsForgetPassword");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "BuildingManagerComment",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "Tickets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Tickets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedTime",
                table: "Tickets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Cities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Countries_CountryId",
                table: "Cities",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Users_BeneficiaryID",
                table: "Tickets",
                column: "BeneficiaryID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Countries_CountryId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Users_BeneficiaryID",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Cities_CountryId",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BuildingManagerComment",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "UpdatedTime",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Cities");

            migrationBuilder.RenameColumn(
                name: "IsForgetPassword",
                table: "Users",
                newName: "ForgetPassword");

            migrationBuilder.AddColumn<int>(
                name: "BeneficiaryTicketId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Buildings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_BeneficiaryTicketId",
                table: "Users",
                column: "BeneficiaryTicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_CountryId",
                table: "Buildings",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Buildings_Countries_CountryId",
                table: "Buildings",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Users_BeneficiaryID",
                table: "Tickets",
                column: "BeneficiaryID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Tickets_BeneficiaryTicketId",
                table: "Users",
                column: "BeneficiaryTicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
