using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class meg2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_ListePlanifications_PlanificationId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "PlanificationId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_ListePlanifications_PlanificationId",
                table: "Users",
                column: "PlanificationId",
                principalTable: "ListePlanifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_ListePlanifications_PlanificationId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "PlanificationId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_ListePlanifications_PlanificationId",
                table: "Users",
                column: "PlanificationId",
                principalTable: "ListePlanifications",
                principalColumn: "Id");
        }
    }
}
