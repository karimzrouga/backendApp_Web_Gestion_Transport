using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class megf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Stations",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Stations",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "CircuitShift",
                columns: table => new
                {
                    CircuitsId = table.Column<int>(type: "int", nullable: false),
                    ShiftsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CircuitShift", x => new { x.CircuitsId, x.ShiftsId });
                    table.ForeignKey(
                        name: "FK_CircuitShift_Circuits_CircuitsId",
                        column: x => x.CircuitsId,
                        principalTable: "Circuits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CircuitShift_Shifts_ShiftsId",
                        column: x => x.ShiftsId,
                        principalTable: "Shifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CircuitShift_ShiftsId",
                table: "CircuitShift",
                column: "ShiftsId");

            migrationBuilder.InsertData(
            table: "Roles",
            columns: new[] { "RoleName", "Description", "CreatedAt", "UpdatedAt" },
            values: new object[,]
            {
            { "admin", "Description for admin", DateTime.Now, DateTime.Now },
            { "employe", "Description for employe", DateTime.Now, DateTime.Now },
            { "responsabletransport", "Description for responsabletransport", DateTime.Now, DateTime.Now },
            { "Key-user", "Description for Key-user", DateTime.Now, DateTime.Now },
            { "Servicepaie", "Description for Servicepaie", DateTime.Now, DateTime.Now },
            { "ChefSegment", "Description for ChefSegment", DateTime.Now, DateTime.Now },
            { "RhSegment", "Description for RhSegment", DateTime.Now, DateTime.Now },
            { "Psmanger", "Description for ChefSegment", DateTime.Now, DateTime.Now },
            });
            migrationBuilder.InsertData(
            table: "ListePlanifications",
            columns: new[] { "PlanificationName", "Entre", "Sortie", "Repos", "CreatedAt", "UpdatedAt" },
            values: new object[,]
            {
            { "Default Planification ", DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now },

            });
            migrationBuilder.InsertData(
            table: "Shifts",
            columns: new[] { "Entre", "Sortie", "CreatedDate", "CreatedAt", "UpdatedAt" },
            values: new object[,]
            {
            { DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now },
            { DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now }
            });
            migrationBuilder.InsertData(
            table: "Permissions",
            columns: new[] { "title", "description", "CreatedAt", "UpdatedAt" },
            values: new object[,]
            {
            { "ADD,Delete,Update,Create,Consulte","for admin", DateTime.Now, DateTime.Now},

            });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CircuitShift");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Stations");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Stations");
        }
    }
}
