using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanA.Migrations
{
    /// <inheritdoc />
    public partial class equi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeEquipment_Equipment_EquipmentsId",
                table: "EmployeeEquipment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Equipment",
                table: "Equipment");

            migrationBuilder.RenameTable(
                name: "Equipment",
                newName: "Equipments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Equipments",
                table: "Equipments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeEquipment_Equipments_EquipmentsId",
                table: "EmployeeEquipment",
                column: "EquipmentsId",
                principalTable: "Equipments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeEquipment_Equipments_EquipmentsId",
                table: "EmployeeEquipment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Equipments",
                table: "Equipments");

            migrationBuilder.RenameTable(
                name: "Equipments",
                newName: "Equipment");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Equipment",
                table: "Equipment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeEquipment_Equipment_EquipmentsId",
                table: "EmployeeEquipment",
                column: "EquipmentsId",
                principalTable: "Equipment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
