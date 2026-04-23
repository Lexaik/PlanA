using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanA.Migrations
{
    /// <inheritdoc />
    public partial class new_subprocess : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Processes_Processes_ProcessId",
                table: "Processes");

            migrationBuilder.DropForeignKey(
                name: "FK_Sub_Processes_Processes_Sub_ProcessId",
                table: "Sub_Processes");

            migrationBuilder.DropIndex(
                name: "IX_Sub_Processes_Sub_ProcessId",
                table: "Sub_Processes");

            migrationBuilder.DropIndex(
                name: "IX_Processes_ProcessId",
                table: "Processes");

            migrationBuilder.DropColumn(
                name: "Sub_ProcessId",
                table: "Sub_Processes");

            migrationBuilder.DropColumn(
                name: "ProcessId",
                table: "Processes");

            migrationBuilder.CreateIndex(
                name: "IX_Sub_Processes_SubProcessId",
                table: "Sub_Processes",
                column: "SubProcessId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sub_Processes_Processes_SubProcessId",
                table: "Sub_Processes",
                column: "SubProcessId",
                principalTable: "Processes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sub_Processes_Processes_SubProcessId",
                table: "Sub_Processes");

            migrationBuilder.DropIndex(
                name: "IX_Sub_Processes_SubProcessId",
                table: "Sub_Processes");

            migrationBuilder.AddColumn<int>(
                name: "Sub_ProcessId",
                table: "Sub_Processes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProcessId",
                table: "Processes",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sub_Processes_Sub_ProcessId",
                table: "Sub_Processes",
                column: "Sub_ProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_Processes_ProcessId",
                table: "Processes",
                column: "ProcessId");

            migrationBuilder.AddForeignKey(
                name: "FK_Processes_Processes_ProcessId",
                table: "Processes",
                column: "ProcessId",
                principalTable: "Processes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sub_Processes_Processes_Sub_ProcessId",
                table: "Sub_Processes",
                column: "Sub_ProcessId",
                principalTable: "Processes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
