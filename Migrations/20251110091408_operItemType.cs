using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanA.Migrations
{
    /// <inheritdoc />
    public partial class operItemType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OperationItemType",
                table: "Operation_Items",
                newName: "ItemType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ItemType",
                table: "Operation_Items",
                newName: "OperationItemType");
        }
    }
}
