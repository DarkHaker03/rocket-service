using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class TrueProductBill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_uw_product_way_uw_product_ProductId",
                table: "uw_product_way");

            migrationBuilder.DropForeignKey(
                name: "FK_uw_product_way_uw_waste_bill_WasteBillId",
                table: "uw_product_way");

            migrationBuilder.DropPrimaryKey(
                name: "PK_uw_product_way",
                table: "uw_product_way");

            migrationBuilder.RenameTable(
                name: "uw_product_way",
                newName: "uw_product_waste");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "uw_product_waste",
                newName: "ReceivedProductId");

            migrationBuilder.RenameIndex(
                name: "IX_uw_product_way_WasteBillId",
                table: "uw_product_waste",
                newName: "IX_uw_product_waste_WasteBillId");

            migrationBuilder.RenameIndex(
                name: "IX_uw_product_way_ProductId",
                table: "uw_product_waste",
                newName: "IX_uw_product_waste_ReceivedProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_uw_product_waste",
                table: "uw_product_waste",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_uw_product_waste_uw_received_product_ReceivedProductId",
                table: "uw_product_waste",
                column: "ReceivedProductId",
                principalTable: "uw_received_product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_uw_product_waste_uw_waste_bill_WasteBillId",
                table: "uw_product_waste",
                column: "WasteBillId",
                principalTable: "uw_waste_bill",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_uw_product_waste_uw_received_product_ReceivedProductId",
                table: "uw_product_waste");

            migrationBuilder.DropForeignKey(
                name: "FK_uw_product_waste_uw_waste_bill_WasteBillId",
                table: "uw_product_waste");

            migrationBuilder.DropPrimaryKey(
                name: "PK_uw_product_waste",
                table: "uw_product_waste");

            migrationBuilder.RenameTable(
                name: "uw_product_waste",
                newName: "uw_product_way");

            migrationBuilder.RenameColumn(
                name: "ReceivedProductId",
                table: "uw_product_way",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_uw_product_waste_WasteBillId",
                table: "uw_product_way",
                newName: "IX_uw_product_way_WasteBillId");

            migrationBuilder.RenameIndex(
                name: "IX_uw_product_waste_ReceivedProductId",
                table: "uw_product_way",
                newName: "IX_uw_product_way_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_uw_product_way",
                table: "uw_product_way",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_uw_product_way_uw_product_ProductId",
                table: "uw_product_way",
                column: "ProductId",
                principalTable: "uw_product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_uw_product_way_uw_waste_bill_WasteBillId",
                table: "uw_product_way",
                column: "WasteBillId",
                principalTable: "uw_waste_bill",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
