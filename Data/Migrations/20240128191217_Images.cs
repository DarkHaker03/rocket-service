using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Images : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_uw_way_bill_uw_product_ProductId",
                table: "uw_way_bill");

            migrationBuilder.DropIndex(
                name: "IX_uw_way_bill_ProductId",
                table: "uw_way_bill");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "uw_way_bill");

            migrationBuilder.DropColumn(
                name: "PhotoLink",
                table: "uw_product");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "uw_product",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "uw_images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ObjectCreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uw_images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "uw_product_way",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    WayBillId = table.Column<Guid>(type: "uuid", nullable: false),
                    ObjectCreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uw_product_way", x => x.Id);
                    table.ForeignKey(
                        name: "FK_uw_product_way_uw_product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "uw_product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_uw_product_way_uw_way_bill_WayBillId",
                        column: x => x.WayBillId,
                        principalTable: "uw_way_bill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "uw_product_link",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ImageId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    ObjectCreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uw_product_link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_uw_product_link_uw_images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "uw_images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_uw_product_link_uw_product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "uw_product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_uw_product_link_ImageId",
                table: "uw_product_link",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_uw_product_link_ProductId",
                table: "uw_product_link",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_uw_product_way_ProductId",
                table: "uw_product_way",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_uw_product_way_WayBillId",
                table: "uw_product_way",
                column: "WayBillId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "uw_product_link");

            migrationBuilder.DropTable(
                name: "uw_product_way");

            migrationBuilder.DropTable(
                name: "uw_images");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "uw_product");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "uw_way_bill",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "PhotoLink",
                table: "uw_product",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_uw_way_bill_ProductId",
                table: "uw_way_bill",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_uw_way_bill_uw_product_ProductId",
                table: "uw_way_bill",
                column: "ProductId",
                principalTable: "uw_product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
