using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class BillsUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActualArrivalAt",
                table: "WasteBills");

            migrationBuilder.AddColumn<Guid>(
                name: "CarId",
                table: "WayBills",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "WarehouseId",
                table: "WayBills",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "ActualLeaveAt",
                table: "WasteBills",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WayBills_CarId",
                table: "WayBills",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_WayBills_WarehouseId",
                table: "WayBills",
                column: "WarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_WayBills_Cars_CarId",
                table: "WayBills",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WayBills_Warehouses_WarehouseId",
                table: "WayBills",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WayBills_Cars_CarId",
                table: "WayBills");

            migrationBuilder.DropForeignKey(
                name: "FK_WayBills_Warehouses_WarehouseId",
                table: "WayBills");

            migrationBuilder.DropIndex(
                name: "IX_WayBills_CarId",
                table: "WayBills");

            migrationBuilder.DropIndex(
                name: "IX_WayBills_WarehouseId",
                table: "WayBills");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "WayBills");

            migrationBuilder.DropColumn(
                name: "WarehouseId",
                table: "WayBills");

            migrationBuilder.DropColumn(
                name: "ActualLeaveAt",
                table: "WasteBills");

            migrationBuilder.AddColumn<DateTime>(
                name: "ActualArrivalAt",
                table: "WasteBills",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
