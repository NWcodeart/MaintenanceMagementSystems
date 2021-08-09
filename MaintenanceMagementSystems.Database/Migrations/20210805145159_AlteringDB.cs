using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MaintenanceManagementSystem.Database.Migrations
{
    public partial class AlteringDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buildings_Countries_CountryId",
                table: "Buildings");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Tickets_BeneficiaryTicketId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "UserTickets");

            migrationBuilder.RenameColumn(
                name: "ForgetPassword",
                table: "Users",
                newName: "IsForgetPassword");

            migrationBuilder.RenameColumn(
                name: "BeneficiaryTicketId",
                table: "Users",
                newName: "buildingId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_BeneficiaryTicketId",
                table: "Users",
                newName: "IX_Users_buildingId");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "Buildings",
                newName: "BuildingManagerId");

            migrationBuilder.RenameIndex(
                name: "IX_Buildings_CountryId",
                table: "Buildings",
                newName: "IX_Buildings_BuildingManagerId");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "BeneficiaryID",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateTable(
                name: "BackOfficesTickets",
                columns: table => new
                {
                    TicketId = table.Column<int>(type: "int", nullable: false),
                    BackOfficeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BackOfficesTickets", x => new { x.BackOfficeId, x.TicketId });
                    table.ForeignKey(
                        name: "FK_BackOfficesTickets_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BackOfficesTickets_Users_BackOfficeId",
                        column: x => x.BackOfficeId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_BeneficiaryID",
                table: "Tickets",
                column: "BeneficiaryID");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_BackOfficesTickets_TicketId",
                table: "BackOfficesTickets",
                column: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Buildings_Users_BuildingManagerId",
                table: "Buildings",
                column: "BuildingManagerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Cities_Countries_CountryId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Users_BeneficiaryID",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Buildings_buildingId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "BackOfficesTickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_BeneficiaryID",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Cities_CountryId",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BeneficiaryID",
                table: "Tickets");

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
                name: "buildingId",
                table: "Users",
                newName: "BeneficiaryTicketId");

            migrationBuilder.RenameColumn(
                name: "IsForgetPassword",
                table: "Users",
                newName: "ForgetPassword");

            migrationBuilder.RenameIndex(
                name: "IX_Users_buildingId",
                table: "Users",
                newName: "IX_Users_BeneficiaryTicketId");

            migrationBuilder.RenameColumn(
                name: "BuildingManagerId",
                table: "Buildings",
                newName: "CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Buildings_BuildingManagerId",
                table: "Buildings",
                newName: "IX_Buildings_CountryId");

            migrationBuilder.CreateTable(
                name: "UserTickets",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TicketId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTickets", x => new { x.UserId, x.TicketId });
                    table.ForeignKey(
                        name: "FK_UserTickets_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTickets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserTickets_TicketId",
                table: "UserTickets",
                column: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Buildings_Countries_CountryId",
                table: "Buildings",
                column: "CountryId",
                principalTable: "Countries",
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
