using Microsoft.EntityFrameworkCore.Migrations;

namespace MaintenanceManagementSystem.Database.Migrations
{
    public partial class RemoveOneToOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Tickets_BeneficiaryTicketId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "BackOfficesTickets");

            migrationBuilder.DropIndex(
                name: "IX_Users_BeneficiaryTicketId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_BeneficiaryID",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "BeneficiaryTicketId",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "UserTickets",
                columns: table => new
                {
                    TicketId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
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
                name: "IX_Tickets_BeneficiaryID",
                table: "Tickets",
                column: "BeneficiaryID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserTickets_TicketId",
                table: "UserTickets",
                column: "TicketId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserTickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_BeneficiaryID",
                table: "Tickets");

            migrationBuilder.AddColumn<int>(
                name: "BeneficiaryTicketId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BackOfficesTickets",
                columns: table => new
                {
                    BackOfficeId = table.Column<int>(type: "int", nullable: false),
                    TicketId = table.Column<int>(type: "int", nullable: false)
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
                name: "IX_Users_BeneficiaryTicketId",
                table: "Users",
                column: "BeneficiaryTicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_BeneficiaryID",
                table: "Tickets",
                column: "BeneficiaryID");

            migrationBuilder.CreateIndex(
                name: "IX_BackOfficesTickets_TicketId",
                table: "BackOfficesTickets",
                column: "TicketId");

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
