using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PlanA.Migrations
{
    /// <inheritdoc />
    public partial class _111222333 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Assets_ItemId",
                table: "Assets");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeEquipment_Employees_EmployeesId",
                table: "EmployeeEquipment");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeEquipment_Equipments_EquipmentsId",
                table: "EmployeeEquipment");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Persons_PersonId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemOperation_Assets_ItemsId",
                table: "ItemOperation");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemOperation_Operations_OperationsId",
                table: "ItemOperation");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemOrder_Assets_ItemsId",
                table: "ItemOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemOrder_Orders_OrdersId",
                table: "ItemOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_Operation_Items_Assets_ItemId",
                table: "Operation_Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Operation_Items_Operations_OperationId",
                table: "Operation_Items");

            migrationBuilder.DropForeignKey(
                name: "FK_OperationProcess_Operations_OperationsId",
                table: "OperationProcess");

            migrationBuilder.DropForeignKey(
                name: "FK_OperationProcess_Processes_ProcessesId",
                table: "OperationProcess");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Items_Assets_ItemId",
                table: "Order_Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Items_Orders_OrderId",
                table: "Order_Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Sub_Items_Assets_ItemId",
                table: "Sub_Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Sub_Items_Assets_SubItemId",
                table: "Sub_Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Sub_Processes_Processes_ProcessId",
                table: "Sub_Processes");

            migrationBuilder.DropForeignKey(
                name: "FK_Sub_Processes_Processes_SubProcessId",
                table: "Sub_Processes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sub_Processes",
                table: "Sub_Processes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sub_Items",
                table: "Sub_Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Processes",
                table: "Processes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Persons",
                table: "Persons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order_Items",
                table: "Order_Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Operations",
                table: "Operations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Operation_Items",
                table: "Operation_Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Equipments",
                table: "Equipments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Assets",
                table: "Assets");

            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.RenameTable(
                name: "Sub_Processes",
                newName: "sub_processes",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "Sub_Items",
                newName: "sub_items",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "Processes",
                newName: "processes",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "Persons",
                newName: "persons",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "orders",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "Order_Items",
                newName: "order_items",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "Operations",
                newName: "operations",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "OperationProcess",
                newName: "OperationProcess",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "Operation_Items",
                newName: "operation_items",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "ItemOrder",
                newName: "ItemOrder",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "ItemOperation",
                newName: "ItemOperation",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "Equipments",
                newName: "equipments",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "employees",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "EmployeeEquipment",
                newName: "EmployeeEquipment",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "Assets",
                newName: "assets",
                newSchema: "public");

            migrationBuilder.RenameIndex(
                name: "IX_Sub_Processes_SubProcessId",
                schema: "public",
                table: "sub_processes",
                newName: "IX_sub_processes_SubProcessId");

            migrationBuilder.RenameIndex(
                name: "IX_Sub_Items_SubItemId",
                schema: "public",
                table: "sub_items",
                newName: "IX_sub_items_SubItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_Items_OrderId",
                schema: "public",
                table: "order_items",
                newName: "IX_order_items_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Operation_Items_OperationId",
                schema: "public",
                table: "operation_items",
                newName: "IX_operation_items_OperationId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_PersonId",
                schema: "public",
                table: "employees",
                newName: "IX_employees_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Assets_ItemId",
                schema: "public",
                table: "assets",
                newName: "IX_assets_ItemId");

            migrationBuilder.AlterColumn<int>(
                name: "SubProcessId",
                schema: "public",
                table: "sub_processes",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "ProcessId",
                schema: "public",
                table: "sub_processes",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                schema: "public",
                table: "sub_items",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "SubItemId",
                schema: "public",
                table: "sub_items",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                schema: "public",
                table: "sub_items",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                schema: "public",
                table: "processes",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "public",
                table: "processes",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Duration",
                schema: "public",
                table: "processes",
                type: "interval",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "public",
                table: "processes",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                schema: "public",
                table: "persons",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Patronymic",
                schema: "public",
                table: "persons",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "public",
                table: "persons",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                schema: "public",
                table: "persons",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Birthday",
                schema: "public",
                table: "persons",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                schema: "public",
                table: "persons",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "public",
                table: "persons",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PlanDateStart",
                schema: "public",
                table: "orders",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PlanDateEnd",
                schema: "public",
                table: "orders",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderCreated",
                schema: "public",
                table: "orders",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "public",
                table: "orders",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "public",
                table: "orders",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualDateStart",
                schema: "public",
                table: "orders",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualDateEnd",
                schema: "public",
                table: "orders",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "public",
                table: "orders",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                schema: "public",
                table: "order_items",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                schema: "public",
                table: "order_items",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                schema: "public",
                table: "order_items",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "public",
                table: "operations",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Duration",
                schema: "public",
                table: "operations",
                type: "interval",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "public",
                table: "operations",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "ProcessesId",
                schema: "public",
                table: "OperationProcess",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "OperationsId",
                schema: "public",
                table: "OperationProcess",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                schema: "public",
                table: "operation_items",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "ItemType",
                schema: "public",
                table: "operation_items",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "OperationId",
                schema: "public",
                table: "operation_items",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                schema: "public",
                table: "operation_items",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "OrdersId",
                schema: "public",
                table: "ItemOrder",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "ItemsId",
                schema: "public",
                table: "ItemOrder",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "OperationsId",
                schema: "public",
                table: "ItemOperation",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "ItemsId",
                schema: "public",
                table: "ItemOperation",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "public",
                table: "equipments",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<double>(
                name: "Cost",
                schema: "public",
                table: "equipments",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "REAL");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "public",
                table: "equipments",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<double>(
                name: "Salary",
                schema: "public",
                table: "employees",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "REAL");

            migrationBuilder.AlterColumn<string>(
                name: "Profession",
                schema: "public",
                table: "employees",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                schema: "public",
                table: "employees",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "public",
                table: "employees",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "EquipmentsId",
                schema: "public",
                table: "EmployeeEquipment",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeesId",
                schema: "public",
                table: "EmployeeEquipment",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                schema: "public",
                table: "assets",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "public",
                table: "assets",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                schema: "public",
                table: "assets",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "public",
                table: "assets",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_sub_processes",
                schema: "public",
                table: "sub_processes",
                columns: new[] { "ProcessId", "SubProcessId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_sub_items",
                schema: "public",
                table: "sub_items",
                columns: new[] { "ItemId", "SubItemId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_processes",
                schema: "public",
                table: "processes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_persons",
                schema: "public",
                table: "persons",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orders",
                schema: "public",
                table: "orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_order_items",
                schema: "public",
                table: "order_items",
                columns: new[] { "ItemId", "OrderId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_operations",
                schema: "public",
                table: "operations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_operation_items",
                schema: "public",
                table: "operation_items",
                columns: new[] { "ItemId", "OperationId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_equipments",
                schema: "public",
                table: "equipments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_employees",
                schema: "public",
                table: "employees",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_assets",
                schema: "public",
                table: "assets",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_assets_assets_ItemId",
                schema: "public",
                table: "assets",
                column: "ItemId",
                principalSchema: "public",
                principalTable: "assets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeEquipment_employees_EmployeesId",
                schema: "public",
                table: "EmployeeEquipment",
                column: "EmployeesId",
                principalSchema: "public",
                principalTable: "employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeEquipment_equipments_EquipmentsId",
                schema: "public",
                table: "EmployeeEquipment",
                column: "EquipmentsId",
                principalSchema: "public",
                principalTable: "equipments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_employees_persons_PersonId",
                schema: "public",
                table: "employees",
                column: "PersonId",
                principalSchema: "public",
                principalTable: "persons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemOperation_assets_ItemsId",
                schema: "public",
                table: "ItemOperation",
                column: "ItemsId",
                principalSchema: "public",
                principalTable: "assets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemOperation_operations_OperationsId",
                schema: "public",
                table: "ItemOperation",
                column: "OperationsId",
                principalSchema: "public",
                principalTable: "operations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemOrder_assets_ItemsId",
                schema: "public",
                table: "ItemOrder",
                column: "ItemsId",
                principalSchema: "public",
                principalTable: "assets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemOrder_orders_OrdersId",
                schema: "public",
                table: "ItemOrder",
                column: "OrdersId",
                principalSchema: "public",
                principalTable: "orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_operation_items_assets_ItemId",
                schema: "public",
                table: "operation_items",
                column: "ItemId",
                principalSchema: "public",
                principalTable: "assets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_operation_items_operations_OperationId",
                schema: "public",
                table: "operation_items",
                column: "OperationId",
                principalSchema: "public",
                principalTable: "operations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OperationProcess_operations_OperationsId",
                schema: "public",
                table: "OperationProcess",
                column: "OperationsId",
                principalSchema: "public",
                principalTable: "operations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OperationProcess_processes_ProcessesId",
                schema: "public",
                table: "OperationProcess",
                column: "ProcessesId",
                principalSchema: "public",
                principalTable: "processes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_order_items_assets_ItemId",
                schema: "public",
                table: "order_items",
                column: "ItemId",
                principalSchema: "public",
                principalTable: "assets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_order_items_orders_OrderId",
                schema: "public",
                table: "order_items",
                column: "OrderId",
                principalSchema: "public",
                principalTable: "orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sub_items_assets_ItemId",
                schema: "public",
                table: "sub_items",
                column: "ItemId",
                principalSchema: "public",
                principalTable: "assets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sub_items_assets_SubItemId",
                schema: "public",
                table: "sub_items",
                column: "SubItemId",
                principalSchema: "public",
                principalTable: "assets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sub_processes_processes_ProcessId",
                schema: "public",
                table: "sub_processes",
                column: "ProcessId",
                principalSchema: "public",
                principalTable: "processes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sub_processes_processes_SubProcessId",
                schema: "public",
                table: "sub_processes",
                column: "SubProcessId",
                principalSchema: "public",
                principalTable: "processes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_assets_assets_ItemId",
                schema: "public",
                table: "assets");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeEquipment_employees_EmployeesId",
                schema: "public",
                table: "EmployeeEquipment");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeEquipment_equipments_EquipmentsId",
                schema: "public",
                table: "EmployeeEquipment");

            migrationBuilder.DropForeignKey(
                name: "FK_employees_persons_PersonId",
                schema: "public",
                table: "employees");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemOperation_assets_ItemsId",
                schema: "public",
                table: "ItemOperation");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemOperation_operations_OperationsId",
                schema: "public",
                table: "ItemOperation");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemOrder_assets_ItemsId",
                schema: "public",
                table: "ItemOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemOrder_orders_OrdersId",
                schema: "public",
                table: "ItemOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_operation_items_assets_ItemId",
                schema: "public",
                table: "operation_items");

            migrationBuilder.DropForeignKey(
                name: "FK_operation_items_operations_OperationId",
                schema: "public",
                table: "operation_items");

            migrationBuilder.DropForeignKey(
                name: "FK_OperationProcess_operations_OperationsId",
                schema: "public",
                table: "OperationProcess");

            migrationBuilder.DropForeignKey(
                name: "FK_OperationProcess_processes_ProcessesId",
                schema: "public",
                table: "OperationProcess");

            migrationBuilder.DropForeignKey(
                name: "FK_order_items_assets_ItemId",
                schema: "public",
                table: "order_items");

            migrationBuilder.DropForeignKey(
                name: "FK_order_items_orders_OrderId",
                schema: "public",
                table: "order_items");

            migrationBuilder.DropForeignKey(
                name: "FK_sub_items_assets_ItemId",
                schema: "public",
                table: "sub_items");

            migrationBuilder.DropForeignKey(
                name: "FK_sub_items_assets_SubItemId",
                schema: "public",
                table: "sub_items");

            migrationBuilder.DropForeignKey(
                name: "FK_sub_processes_processes_ProcessId",
                schema: "public",
                table: "sub_processes");

            migrationBuilder.DropForeignKey(
                name: "FK_sub_processes_processes_SubProcessId",
                schema: "public",
                table: "sub_processes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_sub_processes",
                schema: "public",
                table: "sub_processes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_sub_items",
                schema: "public",
                table: "sub_items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_processes",
                schema: "public",
                table: "processes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_persons",
                schema: "public",
                table: "persons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_orders",
                schema: "public",
                table: "orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_order_items",
                schema: "public",
                table: "order_items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_operations",
                schema: "public",
                table: "operations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_operation_items",
                schema: "public",
                table: "operation_items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_equipments",
                schema: "public",
                table: "equipments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_employees",
                schema: "public",
                table: "employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_assets",
                schema: "public",
                table: "assets");

            migrationBuilder.RenameTable(
                name: "sub_processes",
                schema: "public",
                newName: "Sub_Processes");

            migrationBuilder.RenameTable(
                name: "sub_items",
                schema: "public",
                newName: "Sub_Items");

            migrationBuilder.RenameTable(
                name: "processes",
                schema: "public",
                newName: "Processes");

            migrationBuilder.RenameTable(
                name: "persons",
                schema: "public",
                newName: "Persons");

            migrationBuilder.RenameTable(
                name: "orders",
                schema: "public",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "order_items",
                schema: "public",
                newName: "Order_Items");

            migrationBuilder.RenameTable(
                name: "operations",
                schema: "public",
                newName: "Operations");

            migrationBuilder.RenameTable(
                name: "OperationProcess",
                schema: "public",
                newName: "OperationProcess");

            migrationBuilder.RenameTable(
                name: "operation_items",
                schema: "public",
                newName: "Operation_Items");

            migrationBuilder.RenameTable(
                name: "ItemOrder",
                schema: "public",
                newName: "ItemOrder");

            migrationBuilder.RenameTable(
                name: "ItemOperation",
                schema: "public",
                newName: "ItemOperation");

            migrationBuilder.RenameTable(
                name: "equipments",
                schema: "public",
                newName: "Equipments");

            migrationBuilder.RenameTable(
                name: "employees",
                schema: "public",
                newName: "Employees");

            migrationBuilder.RenameTable(
                name: "EmployeeEquipment",
                schema: "public",
                newName: "EmployeeEquipment");

            migrationBuilder.RenameTable(
                name: "assets",
                schema: "public",
                newName: "Assets");

            migrationBuilder.RenameIndex(
                name: "IX_sub_processes_SubProcessId",
                table: "Sub_Processes",
                newName: "IX_Sub_Processes_SubProcessId");

            migrationBuilder.RenameIndex(
                name: "IX_sub_items_SubItemId",
                table: "Sub_Items",
                newName: "IX_Sub_Items_SubItemId");

            migrationBuilder.RenameIndex(
                name: "IX_order_items_OrderId",
                table: "Order_Items",
                newName: "IX_Order_Items_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_operation_items_OperationId",
                table: "Operation_Items",
                newName: "IX_Operation_Items_OperationId");

            migrationBuilder.RenameIndex(
                name: "IX_employees_PersonId",
                table: "Employees",
                newName: "IX_Employees_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_assets_ItemId",
                table: "Assets",
                newName: "IX_Assets_ItemId");

            migrationBuilder.AlterColumn<int>(
                name: "SubProcessId",
                table: "Sub_Processes",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ProcessId",
                table: "Sub_Processes",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "Sub_Items",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "SubItemId",
                table: "Sub_Items",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "Sub_Items",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "Processes",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Processes",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Duration",
                table: "Processes",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "interval");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Processes",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Persons",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Patronymic",
                table: "Persons",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Persons",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Persons",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Birthday",
                table: "Persons",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Persons",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Persons",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "PlanDateStart",
                table: "Orders",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "PlanDateEnd",
                table: "Orders",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "OrderCreated",
                table: "Orders",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Orders",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<int>(
                name: "IsActive",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "ActualDateStart",
                table: "Orders",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ActualDateEnd",
                table: "Orders",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "Order_Items",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "Order_Items",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "Order_Items",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Operations",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Duration",
                table: "Operations",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "interval");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Operations",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "ProcessesId",
                table: "OperationProcess",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "OperationsId",
                table: "OperationProcess",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "Operation_Items",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "ItemType",
                table: "Operation_Items",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "OperationId",
                table: "Operation_Items",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "Operation_Items",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "OrdersId",
                table: "ItemOrder",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ItemsId",
                table: "ItemOrder",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "OperationsId",
                table: "ItemOperation",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ItemsId",
                table: "ItemOperation",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Equipments",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<float>(
                name: "Cost",
                table: "Equipments",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Equipments",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<float>(
                name: "Salary",
                table: "Employees",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<string>(
                name: "Profession",
                table: "Employees",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "Employees",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Employees",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "EquipmentsId",
                table: "EmployeeEquipment",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeesId",
                table: "EmployeeEquipment",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "Assets",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Assets",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "Assets",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Assets",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sub_Processes",
                table: "Sub_Processes",
                columns: new[] { "ProcessId", "SubProcessId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sub_Items",
                table: "Sub_Items",
                columns: new[] { "ItemId", "SubItemId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Processes",
                table: "Processes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persons",
                table: "Persons",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order_Items",
                table: "Order_Items",
                columns: new[] { "ItemId", "OrderId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Operations",
                table: "Operations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Operation_Items",
                table: "Operation_Items",
                columns: new[] { "ItemId", "OperationId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Equipments",
                table: "Equipments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Assets",
                table: "Assets",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Assets_ItemId",
                table: "Assets",
                column: "ItemId",
                principalTable: "Assets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeEquipment_Employees_EmployeesId",
                table: "EmployeeEquipment",
                column: "EmployeesId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeEquipment_Equipments_EquipmentsId",
                table: "EmployeeEquipment",
                column: "EquipmentsId",
                principalTable: "Equipments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Persons_PersonId",
                table: "Employees",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemOperation_Assets_ItemsId",
                table: "ItemOperation",
                column: "ItemsId",
                principalTable: "Assets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemOperation_Operations_OperationsId",
                table: "ItemOperation",
                column: "OperationsId",
                principalTable: "Operations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemOrder_Assets_ItemsId",
                table: "ItemOrder",
                column: "ItemsId",
                principalTable: "Assets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemOrder_Orders_OrdersId",
                table: "ItemOrder",
                column: "OrdersId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Operation_Items_Assets_ItemId",
                table: "Operation_Items",
                column: "ItemId",
                principalTable: "Assets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Operation_Items_Operations_OperationId",
                table: "Operation_Items",
                column: "OperationId",
                principalTable: "Operations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OperationProcess_Operations_OperationsId",
                table: "OperationProcess",
                column: "OperationsId",
                principalTable: "Operations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OperationProcess_Processes_ProcessesId",
                table: "OperationProcess",
                column: "ProcessesId",
                principalTable: "Processes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Items_Assets_ItemId",
                table: "Order_Items",
                column: "ItemId",
                principalTable: "Assets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Items_Orders_OrderId",
                table: "Order_Items",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sub_Items_Assets_ItemId",
                table: "Sub_Items",
                column: "ItemId",
                principalTable: "Assets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sub_Items_Assets_SubItemId",
                table: "Sub_Items",
                column: "SubItemId",
                principalTable: "Assets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sub_Processes_Processes_ProcessId",
                table: "Sub_Processes",
                column: "ProcessId",
                principalTable: "Processes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
