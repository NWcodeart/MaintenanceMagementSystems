using Microsoft.EntityFrameworkCore.Migrations;

namespace MaintenanceManagementSystem.Database.Migrations
{
    public partial class RemoveBenefciryFromTicket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Users_BeneficiaryID",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_BeneficiaryID",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "BeneficiaryID",
                table: "Tickets");

            migrationBuilder.AddColumn<int>(
                name: "BeneficiaryTicketId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_BeneficiaryTicketId",
                table: "Users",
                column: "BeneficiaryTicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Tickets_BeneficiaryTicketId",
                table: "Users",
                column: "BeneficiaryTicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Tickets_BeneficiaryTicketId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_BeneficiaryTicketId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BeneficiaryTicketId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "BeneficiaryID",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_BeneficiaryID",
                table: "Tickets",
                column: "BeneficiaryID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Users_BeneficiaryID",
                table: "Tickets",
                column: "BeneficiaryID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
