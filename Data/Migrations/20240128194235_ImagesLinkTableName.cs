using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class ImagesLinkTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_uw_product_link_uw_images_ImageId",
                table: "uw_product_link");

            migrationBuilder.DropForeignKey(
                name: "FK_uw_product_link_uw_product_ProductId",
                table: "uw_product_link");

            migrationBuilder.DropPrimaryKey(
                name: "PK_uw_product_link",
                table: "uw_product_link");

            migrationBuilder.RenameTable(
                name: "uw_product_link",
                newName: "uw_image_product_link");

            migrationBuilder.RenameIndex(
                name: "IX_uw_product_link_ProductId",
                table: "uw_image_product_link",
                newName: "IX_uw_image_product_link_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_uw_product_link_ImageId",
                table: "uw_image_product_link",
                newName: "IX_uw_image_product_link_ImageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_uw_image_product_link",
                table: "uw_image_product_link",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_uw_image_product_link_uw_images_ImageId",
                table: "uw_image_product_link",
                column: "ImageId",
                principalTable: "uw_images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_uw_image_product_link_uw_product_ProductId",
                table: "uw_image_product_link",
                column: "ProductId",
                principalTable: "uw_product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_uw_image_product_link_uw_images_ImageId",
                table: "uw_image_product_link");

            migrationBuilder.DropForeignKey(
                name: "FK_uw_image_product_link_uw_product_ProductId",
                table: "uw_image_product_link");

            migrationBuilder.DropPrimaryKey(
                name: "PK_uw_image_product_link",
                table: "uw_image_product_link");

            migrationBuilder.RenameTable(
                name: "uw_image_product_link",
                newName: "uw_product_link");

            migrationBuilder.RenameIndex(
                name: "IX_uw_image_product_link_ProductId",
                table: "uw_product_link",
                newName: "IX_uw_product_link_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_uw_image_product_link_ImageId",
                table: "uw_product_link",
                newName: "IX_uw_product_link_ImageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_uw_product_link",
                table: "uw_product_link",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_uw_product_link_uw_images_ImageId",
                table: "uw_product_link",
                column: "ImageId",
                principalTable: "uw_images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_uw_product_link_uw_product_ProductId",
                table: "uw_product_link",
                column: "ProductId",
                principalTable: "uw_product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
