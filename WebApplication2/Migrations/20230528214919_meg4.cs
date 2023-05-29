using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class meg4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_ListePlanifications_PlanificationId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "PlanificationId",
                table: "Users",
                newName: "ListePlanificationId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_PlanificationId",
                table: "Users",
                newName: "IX_Users_ListePlanificationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_ListePlanifications_ListePlanificationId",
                table: "Users",
                column: "ListePlanificationId",
                principalTable: "ListePlanifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_ListePlanifications_ListePlanificationId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "ListePlanificationId",
                table: "Users",
                newName: "PlanificationId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_ListePlanificationId",
                table: "Users",
                newName: "IX_Users_PlanificationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_ListePlanifications_PlanificationId",
                table: "Users",
                column: "PlanificationId",
                principalTable: "ListePlanifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
