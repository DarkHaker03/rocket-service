using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class ProductCell : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_uw_received_product_action_uw_received_product_ReceivedProd~",
                table: "uw_received_product_action");

            migrationBuilder.DropTable(
                name: "uw_written_off_received_product");

            migrationBuilder.DropTable(
                name: "uw_write_off_type");

            migrationBuilder.DropColumn(
                name: "StageId",
                table: "uw_received_product");

            migrationBuilder.DropColumn(
                name: "WasteBillId",
                table: "uw_product_bill");

            migrationBuilder.RenameColumn(
                name: "ReceivedProductId",
                table: "uw_received_product_action",
                newName: "ReceivedProductCellId");

            migrationBuilder.RenameIndex(
                name: "IX_uw_received_product_action_ReceivedProductId",
                table: "uw_received_product_action",
                newName: "IX_uw_received_product_action_ReceivedProductCellId");

            migrationBuilder.AddColumn<string>(
                name: "Barcode",
                table: "uw_received_product",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "ActualQuantity",
                table: "uw_product_bill",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Barcode",
                table: "uw_product_bill",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_uw_received_product_action_uw_received_product_cell_Receive~",
                table: "uw_received_product_action",
                column: "ReceivedProductCellId",
                principalTable: "uw_received_product_cell",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_uw_received_product_action_uw_received_product_cell_Receive~",
                table: "uw_received_product_action");

            migrationBuilder.DropColumn(
                name: "Barcode",
                table: "uw_received_product");

            migrationBuilder.DropColumn(
                name: "ActualQuantity",
                table: "uw_product_bill");

            migrationBuilder.DropColumn(
                name: "Barcode",
                table: "uw_product_bill");

            migrationBuilder.RenameColumn(
                name: "ReceivedProductCellId",
                table: "uw_received_product_action",
                newName: "ReceivedProductId");

            migrationBuilder.RenameIndex(
                name: "IX_uw_received_product_action_ReceivedProductCellId",
                table: "uw_received_product_action",
                newName: "IX_uw_received_product_action_ReceivedProductId");

            migrationBuilder.AddColumn<Guid>(
                name: "StageId",
                table: "uw_received_product",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "WasteBillId",
                table: "uw_product_bill",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "uw_write_off_type",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ObjectCreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uw_write_off_type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "uw_written_off_received_product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uuid", nullable: false),
                    ReceivedProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    TypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    ObjectCreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Quantity = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uw_written_off_received_product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_uw_written_off_received_product_uw_employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "uw_employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_uw_written_off_received_product_uw_received_product_Receive~",
                        column: x => x.ReceivedProductId,
                        principalTable: "uw_received_product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_uw_written_off_received_product_uw_write_off_type_TypeId",
                        column: x => x.TypeId,
                        principalTable: "uw_write_off_type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_uw_written_off_received_product_EmployeeId",
                table: "uw_written_off_received_product",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_uw_written_off_received_product_ReceivedProductId",
                table: "uw_written_off_received_product",
                column: "ReceivedProductId");

            migrationBuilder.CreateIndex(
                name: "IX_uw_written_off_received_product_TypeId",
                table: "uw_written_off_received_product",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_uw_received_product_action_uw_received_product_ReceivedProd~",
                table: "uw_received_product_action",
                column: "ReceivedProductId",
                principalTable: "uw_received_product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
