using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Event_Management.Migrations
{
    /// <inheritdoc />
    public partial class updateTicketConstraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tickets_AttendanceId",
                table: "Tickets");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_AttendanceId",
                table: "Tickets",
                column: "AttendanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_AttendanceId_EventId",
                table: "Tickets",
                columns: new[] { "AttendanceId", "EventId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tickets_AttendanceId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_AttendanceId_EventId",
                table: "Tickets");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_AttendanceId",
                table: "Tickets",
                column: "AttendanceId",
                unique: true);
        }
    }
}
