using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class meg3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

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
            { "Servicefinance", "Description for Servicefinance", DateTime.Now, DateTime.Now },
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
            { "Delete,Update,Create,Consulte","for admin", DateTime.Now, DateTime.Now},

            });
        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
