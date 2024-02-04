using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class ProductsWaste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_uw_product_way_uw_way_bill_WayBillId",
                table: "uw_product_way");

            migrationBuilder.DropForeignKey(
                name: "FK_uw_waste_bill_uw_product_ProductId",
                table: "uw_waste_bill");

            migrationBuilder.DropIndex(
                name: "IX_uw_waste_bill_ProductId",
                table: "uw_waste_bill");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "uw_waste_bill");

            migrationBuilder.RenameColumn(
                name: "WayBillId",
                table: "uw_product_way",
                newName: "WasteBillId");

            migrationBuilder.RenameIndex(
                name: "IX_uw_product_way_WayBillId",
                table: "uw_product_way",
                newName: "IX_uw_product_way_WasteBillId");

            migrationBuilder.AddForeignKey(
                name: "FK_uw_product_way_uw_waste_bill_WasteBillId",
                table: "uw_product_way",
                column: "WasteBillId",
                principalTable: "uw_waste_bill",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_uw_product_way_uw_waste_bill_WasteBillId",
                table: "uw_product_way");

            migrationBuilder.RenameColumn(
                name: "WasteBillId",
                table: "uw_product_way",
                newName: "WayBillId");

            migrationBuilder.RenameIndex(
                name: "IX_uw_product_way_WasteBillId",
                table: "uw_product_way",
                newName: "IX_uw_product_way_WayBillId");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "uw_waste_bill",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_uw_waste_bill_ProductId",
                table: "uw_waste_bill",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_uw_product_way_uw_way_bill_WayBillId",
                table: "uw_product_way",
                column: "WayBillId",
                principalTable: "uw_way_bill",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_uw_waste_bill_uw_product_ProductId",
                table: "uw_waste_bill",
                column: "ProductId",
                principalTable: "uw_product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
