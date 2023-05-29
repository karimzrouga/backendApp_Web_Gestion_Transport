using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class meg6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AgencePlanificationParAgence_Agences_AgencesAgenceId",
                table: "AgencePlanificationParAgence");

            migrationBuilder.DropForeignKey(
                name: "FK_CircuitStation_Circuits_CircuitsCircuitId",
                table: "CircuitStation");

            migrationBuilder.DropForeignKey(
                name: "FK_CircuitStation_Stations_StationsStationId",
                table: "CircuitStation");

            migrationBuilder.DropForeignKey(
                name: "FK_StationVehicule_Stations_StationsStationId",
                table: "StationVehicule");

            migrationBuilder.DropForeignKey(
                name: "FK_StationVehicule_Vehicules_VehiculesVehiculeId",
                table: "StationVehicule");

            migrationBuilder.RenameColumn(
                name: "VehiculeId",
                table: "Vehicules",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "VehiculesVehiculeId",
                table: "StationVehicule",
                newName: "VehiculesId");

            migrationBuilder.RenameColumn(
                name: "StationsStationId",
                table: "StationVehicule",
                newName: "StationsId");

            migrationBuilder.RenameIndex(
                name: "IX_StationVehicule_VehiculesVehiculeId",
                table: "StationVehicule",
                newName: "IX_StationVehicule_VehiculesId");

            migrationBuilder.RenameColumn(
                name: "StationId",
                table: "Stations",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ShiftId",
                table: "Shifts",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "Roles",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PermissionId",
                table: "Permissions",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "FacturationId",
                table: "Facturations",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CotisationId",
                table: "Cotisations",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "StationsStationId",
                table: "CircuitStation",
                newName: "StationsId");

            migrationBuilder.RenameColumn(
                name: "CircuitsCircuitId",
                table: "CircuitStation",
                newName: "CircuitsId");

            migrationBuilder.RenameIndex(
                name: "IX_CircuitStation_StationsStationId",
                table: "CircuitStation",
                newName: "IX_CircuitStation_StationsId");

            migrationBuilder.RenameColumn(
                name: "CircuitId",
                table: "Circuits",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AgenceId",
                table: "Agences",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AgencesAgenceId",
                table: "AgencePlanificationParAgence",
                newName: "AgencesId");

            migrationBuilder.AddForeignKey(
                name: "FK_AgencePlanificationParAgence_Agences_AgencesId",
                table: "AgencePlanificationParAgence",
                column: "AgencesId",
                principalTable: "Agences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CircuitStation_Circuits_CircuitsId",
                table: "CircuitStation",
                column: "CircuitsId",
                principalTable: "Circuits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CircuitStation_Stations_StationsId",
                table: "CircuitStation",
                column: "StationsId",
                principalTable: "Stations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StationVehicule_Stations_StationsId",
                table: "StationVehicule",
                column: "StationsId",
                principalTable: "Stations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StationVehicule_Vehicules_VehiculesId",
                table: "StationVehicule",
                column: "VehiculesId",
                principalTable: "Vehicules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AgencePlanificationParAgence_Agences_AgencesId",
                table: "AgencePlanificationParAgence");

            migrationBuilder.DropForeignKey(
                name: "FK_CircuitStation_Circuits_CircuitsId",
                table: "CircuitStation");

            migrationBuilder.DropForeignKey(
                name: "FK_CircuitStation_Stations_StationsId",
                table: "CircuitStation");

            migrationBuilder.DropForeignKey(
                name: "FK_StationVehicule_Stations_StationsId",
                table: "StationVehicule");

            migrationBuilder.DropForeignKey(
                name: "FK_StationVehicule_Vehicules_VehiculesId",
                table: "StationVehicule");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Vehicules",
                newName: "VehiculeId");

            migrationBuilder.RenameColumn(
                name: "VehiculesId",
                table: "StationVehicule",
                newName: "VehiculesVehiculeId");

            migrationBuilder.RenameColumn(
                name: "StationsId",
                table: "StationVehicule",
                newName: "StationsStationId");

            migrationBuilder.RenameIndex(
                name: "IX_StationVehicule_VehiculesId",
                table: "StationVehicule",
                newName: "IX_StationVehicule_VehiculesVehiculeId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Stations",
                newName: "StationId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Shifts",
                newName: "ShiftId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Roles",
                newName: "RoleId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Permissions",
                newName: "PermissionId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Facturations",
                newName: "FacturationId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Cotisations",
                newName: "CotisationId");

            migrationBuilder.RenameColumn(
                name: "StationsId",
                table: "CircuitStation",
                newName: "StationsStationId");

            migrationBuilder.RenameColumn(
                name: "CircuitsId",
                table: "CircuitStation",
                newName: "CircuitsCircuitId");

            migrationBuilder.RenameIndex(
                name: "IX_CircuitStation_StationsId",
                table: "CircuitStation",
                newName: "IX_CircuitStation_StationsStationId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Circuits",
                newName: "CircuitId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Agences",
                newName: "AgenceId");

            migrationBuilder.RenameColumn(
                name: "AgencesId",
                table: "AgencePlanificationParAgence",
                newName: "AgencesAgenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_AgencePlanificationParAgence_Agences_AgencesAgenceId",
                table: "AgencePlanificationParAgence",
                column: "AgencesAgenceId",
                principalTable: "Agences",
                principalColumn: "AgenceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CircuitStation_Circuits_CircuitsCircuitId",
                table: "CircuitStation",
                column: "CircuitsCircuitId",
                principalTable: "Circuits",
                principalColumn: "CircuitId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CircuitStation_Stations_StationsStationId",
                table: "CircuitStation",
                column: "StationsStationId",
                principalTable: "Stations",
                principalColumn: "StationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StationVehicule_Stations_StationsStationId",
                table: "StationVehicule",
                column: "StationsStationId",
                principalTable: "Stations",
                principalColumn: "StationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StationVehicule_Vehicules_VehiculesVehiculeId",
                table: "StationVehicule",
                column: "VehiculesVehiculeId",
                principalTable: "Vehicules",
                principalColumn: "VehiculeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
