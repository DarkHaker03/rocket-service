using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class StoragePlaces : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CellPlace",
                table: "uw_received_product_cell");

            migrationBuilder.CreateTable(
                name: "uw_cell",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Place = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CreatedByEmployeeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    WarehouseId = table.Column<Guid>(type: "uuid", nullable: false),
                    ObjectCreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uw_cell", x => x.Id);
                    table.ForeignKey(
                        name: "FK_uw_cell_uw_employee_CreatedByEmployeeId",
                        column: x => x.CreatedByEmployeeId,
                        principalTable: "uw_employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_uw_cell_uw_warehouse_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "uw_warehouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

			migrationBuilder.AddColumn<Guid>(
			   name: "CellId",
			   table: "uw_received_product_cell",
			   type: "uuid",
			   nullable: false,
			   defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

			migrationBuilder.CreateIndex(
                name: "IX_uw_received_product_cell_CellId",
                table: "uw_received_product_cell",
                column: "CellId");

            migrationBuilder.CreateIndex(
                name: "IX_uw_cell_CreatedByEmployeeId",
                table: "uw_cell",
                column: "CreatedByEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_uw_cell_WarehouseId",
                table: "uw_cell",
                column: "WarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_uw_received_product_cell_uw_cell_CellId",
                table: "uw_received_product_cell",
                column: "CellId",
                principalTable: "uw_cell",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_uw_received_product_cell_uw_cell_CellId",
                table: "uw_received_product_cell");

            migrationBuilder.DropTable(
                name: "uw_cell");

            migrationBuilder.DropIndex(
                name: "IX_uw_received_product_cell_CellId",
                table: "uw_received_product_cell");

            migrationBuilder.DropColumn(
                name: "CellId",
                table: "uw_received_product_cell");

            migrationBuilder.AddColumn<string>(
                name: "CellPlace",
                table: "uw_received_product_cell",
                type: "text",
                nullable: true);
        }
    }
}
