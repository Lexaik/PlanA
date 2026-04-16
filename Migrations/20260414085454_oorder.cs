using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanA.Migrations
{
    /// <inheritdoc />
    public partial class oorder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderCreated",
                table: "Orders",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Sub_Processes_Sub_ProcessId",
                table: "Sub_Processes",
                column: "Sub_ProcessId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sub_Processes_Processes_Sub_ProcessId",
                table: "Sub_Processes",
                column: "Sub_ProcessId",
                principalTable: "Processes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sub_Processes_Processes_Sub_ProcessId",
                table: "Sub_Processes");

            migrationBuilder.DropIndex(
                name: "IX_Sub_Processes_Sub_ProcessId",
                table: "Sub_Processes");

            migrationBuilder.DropColumn(
                name: "Sub_ProcessId",
                table: "Sub_Processes");

            migrationBuilder.DropColumn(
                name: "OrderCreated",
                table: "Orders");

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
    }
}
