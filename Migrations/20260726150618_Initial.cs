using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NodaTime;

#nullable disable

namespace PlanA.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        /*protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "assets",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ItemId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_assets_assets_ItemId",
                        column: x => x.ItemId,
                        principalSchema: "public",
                        principalTable: "assets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "equipments",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Cost = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_equipments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "operations",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "interval", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_operations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    OrderCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PlanDateStart = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PlanDateEnd = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ActualDateStart = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ActualDateEnd = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "persons",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Patronymic = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Birthday = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "processes",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Duration = table.Column<Period>(type: "interval", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_processes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sub_items",
                schema: "public",
                columns: table => new
                {
                    ItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    SubItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sub_items", x => new { x.ItemId, x.SubItemId });
                    table.ForeignKey(
                        name: "FK_sub_items_assets_ItemId",
                        column: x => x.ItemId,
                        principalSchema: "public",
                        principalTable: "assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sub_items_assets_SubItemId",
                        column: x => x.SubItemId,
                        principalSchema: "public",
                        principalTable: "assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemOperation",
                schema: "public",
                columns: table => new
                {
                    ItemsId = table.Column<Guid>(type: "uuid", nullable: false),
                    OperationsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemOperation", x => new { x.ItemsId, x.OperationsId });
                    table.ForeignKey(
                        name: "FK_ItemOperation_assets_ItemsId",
                        column: x => x.ItemsId,
                        principalSchema: "public",
                        principalTable: "assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemOperation_operations_OperationsId",
                        column: x => x.OperationsId,
                        principalSchema: "public",
                        principalTable: "operations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "operation_items",
                schema: "public",
                columns: table => new
                {
                    OperationId = table.Column<Guid>(type: "uuid", nullable: false),
                    ItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    ItemType = table.Column<string>(type: "text", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_operation_items", x => new { x.ItemId, x.OperationId });
                    table.ForeignKey(
                        name: "FK_operation_items_assets_ItemId",
                        column: x => x.ItemId,
                        principalSchema: "public",
                        principalTable: "assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_operation_items_operations_OperationId",
                        column: x => x.OperationId,
                        principalSchema: "public",
                        principalTable: "operations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemOrder",
                schema: "public",
                columns: table => new
                {
                    ItemsId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrdersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemOrder", x => new { x.ItemsId, x.OrdersId });
                    table.ForeignKey(
                        name: "FK_ItemOrder_assets_ItemsId",
                        column: x => x.ItemsId,
                        principalSchema: "public",
                        principalTable: "assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemOrder_orders_OrdersId",
                        column: x => x.OrdersId,
                        principalSchema: "public",
                        principalTable: "orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "order_items",
                schema: "public",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    ItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_items", x => new { x.ItemId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_order_items_assets_ItemId",
                        column: x => x.ItemId,
                        principalSchema: "public",
                        principalTable: "assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_order_items_orders_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "public",
                        principalTable: "orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Profession = table.Column<string>(type: "text", nullable: false),
                    Salary = table.Column<double>(type: "double precision", nullable: false),
                    PersonId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_employees_persons_PersonId",
                        column: x => x.PersonId,
                        principalSchema: "public",
                        principalTable: "persons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OperationProcess",
                schema: "public",
                columns: table => new
                {
                    OperationsId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProcessesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationProcess", x => new { x.OperationsId, x.ProcessesId });
                    table.ForeignKey(
                        name: "FK_OperationProcess_operations_OperationsId",
                        column: x => x.OperationsId,
                        principalSchema: "public",
                        principalTable: "operations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OperationProcess_processes_ProcessesId",
                        column: x => x.ProcessesId,
                        principalSchema: "public",
                        principalTable: "processes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sub_processes",
                schema: "public",
                columns: table => new
                {
                    ProcessId = table.Column<Guid>(type: "uuid", nullable: false),
                    SubProcessId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sub_processes", x => new { x.ProcessId, x.SubProcessId });
                    table.ForeignKey(
                        name: "FK_sub_processes_processes_ProcessId",
                        column: x => x.ProcessId,
                        principalSchema: "public",
                        principalTable: "processes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sub_processes_processes_SubProcessId",
                        column: x => x.SubProcessId,
                        principalSchema: "public",
                        principalTable: "processes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeEquipment",
                schema: "public",
                columns: table => new
                {
                    EmployeesId = table.Column<Guid>(type: "uuid", nullable: false),
                    EquipmentsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeEquipment", x => new { x.EmployeesId, x.EquipmentsId });
                    table.ForeignKey(
                        name: "FK_EmployeeEquipment_employees_EmployeesId",
                        column: x => x.EmployeesId,
                        principalSchema: "public",
                        principalTable: "employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeEquipment_equipments_EquipmentsId",
                        column: x => x.EquipmentsId,
                        principalSchema: "public",
                        principalTable: "equipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_assets_ItemId",
                schema: "public",
                table: "assets",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEquipment_EquipmentsId",
                schema: "public",
                table: "EmployeeEquipment",
                column: "EquipmentsId");

            migrationBuilder.CreateIndex(
                name: "IX_employees_PersonId",
                schema: "public",
                table: "employees",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemOperation_OperationsId",
                schema: "public",
                table: "ItemOperation",
                column: "OperationsId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemOrder_OrdersId",
                schema: "public",
                table: "ItemOrder",
                column: "OrdersId");

            migrationBuilder.CreateIndex(
                name: "IX_operation_items_OperationId",
                schema: "public",
                table: "operation_items",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_OperationProcess_ProcessesId",
                schema: "public",
                table: "OperationProcess",
                column: "ProcessesId");

            migrationBuilder.CreateIndex(
                name: "IX_order_items_OrderId",
                schema: "public",
                table: "order_items",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_sub_items_SubItemId",
                schema: "public",
                table: "sub_items",
                column: "SubItemId");

            migrationBuilder.CreateIndex(
                name: "IX_sub_processes_SubProcessId",
                schema: "public",
                table: "sub_processes",
                column: "SubProcessId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeEquipment",
                schema: "public");

            migrationBuilder.DropTable(
                name: "ItemOperation",
                schema: "public");

            migrationBuilder.DropTable(
                name: "ItemOrder",
                schema: "public");

            migrationBuilder.DropTable(
                name: "operation_items",
                schema: "public");

            migrationBuilder.DropTable(
                name: "OperationProcess",
                schema: "public");

            migrationBuilder.DropTable(
                name: "order_items",
                schema: "public");

            migrationBuilder.DropTable(
                name: "sub_items",
                schema: "public");

            migrationBuilder.DropTable(
                name: "sub_processes",
                schema: "public");

            migrationBuilder.DropTable(
                name: "employees",
                schema: "public");

            migrationBuilder.DropTable(
                name: "equipments",
                schema: "public");

            migrationBuilder.DropTable(
                name: "operations",
                schema: "public");

            migrationBuilder.DropTable(
                name: "orders",
                schema: "public");

            migrationBuilder.DropTable(
                name: "assets",
                schema: "public");

            migrationBuilder.DropTable(
                name: "processes",
                schema: "public");

            migrationBuilder.DropTable(
                name: "persons",
                schema: "public");
        }*/
    }
}
