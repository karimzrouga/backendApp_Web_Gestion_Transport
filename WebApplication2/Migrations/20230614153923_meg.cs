using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class meg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Immatricule",
                table: "Vehicules",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Matricule",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Matricule",
                table: "Agences",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicules_Immatricule",
                table: "Vehicules",
                column: "Immatricule",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Matricule",
                table: "Users",
                column: "Matricule",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Agences_Matricule",
                table: "Agences",
                column: "Matricule",
                unique: true);


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
            migrationBuilder.DropIndex(
                name: "IX_Vehicules_Immatricule",
                table: "Vehicules");

            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_Matricule",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Agences_Matricule",
                table: "Agences");

            migrationBuilder.AlterColumn<string>(
                name: "Immatricule",
                table: "Vehicules",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Matricule",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Matricule",
                table: "Agences",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
