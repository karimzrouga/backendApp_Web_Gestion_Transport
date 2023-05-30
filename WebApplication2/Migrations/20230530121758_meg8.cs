using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class meg8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanificationParAgences_Agences_AgenceId",
                table: "PlanificationParAgences");

            migrationBuilder.AlterColumn<int>(
                name: "AgenceId",
                table: "PlanificationParAgences",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanificationParAgences_Agences_AgenceId",
                table: "PlanificationParAgences",
                column: "AgenceId",
                principalTable: "Agences",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanificationParAgences_Agences_AgenceId",
                table: "PlanificationParAgences");

            migrationBuilder.AlterColumn<int>(
                name: "AgenceId",
                table: "PlanificationParAgences",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanificationParAgences_Agences_AgenceId",
                table: "PlanificationParAgences",
                column: "AgenceId",
                principalTable: "Agences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
