using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class ProductStages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "StageId",
                table: "WayBills",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "StageId",
                table: "WasteBills",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "StageId",
                table: "ReceivedProducts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "ProductStages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Stage = table.Column<string>(type: "text", nullable: false),
                    ObjectCreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductStages", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WayBills_StageId",
                table: "WayBills",
                column: "StageId");

            migrationBuilder.CreateIndex(
                name: "IX_WasteBills_StageId",
                table: "WasteBills",
                column: "StageId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivedProducts_StageId",
                table: "ReceivedProducts",
                column: "StageId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceivedProducts_ProductStages_StageId",
                table: "ReceivedProducts",
                column: "StageId",
                principalTable: "ProductStages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WasteBills_ProductStages_StageId",
                table: "WasteBills",
                column: "StageId",
                principalTable: "ProductStages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WayBills_ProductStages_StageId",
                table: "WayBills",
                column: "StageId",
                principalTable: "ProductStages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

			migrationBuilder.InsertData(
			   table: "ProductStages",
			   columns: new[] {"Id","Stage", "ObjectCreateDate" },
			   values: new object[] { Guid.Empty, "Не пришел", DateTime.UtcNow});
		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
		
			migrationBuilder.DropForeignKey(
                name: "FK_ReceivedProducts_ProductStages_StageId",
                table: "ReceivedProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_WasteBills_ProductStages_StageId",
                table: "WasteBills");

            migrationBuilder.DropForeignKey(
                name: "FK_WayBills_ProductStages_StageId",
                table: "WayBills");

            migrationBuilder.DropTable(
                name: "ProductStages");

            migrationBuilder.DropIndex(
                name: "IX_WayBills_StageId",
                table: "WayBills");

            migrationBuilder.DropIndex(
                name: "IX_WasteBills_StageId",
                table: "WasteBills");

            migrationBuilder.DropIndex(
                name: "IX_ReceivedProducts_StageId",
                table: "ReceivedProducts");

            migrationBuilder.DropColumn(
                name: "StageId",
                table: "WayBills");

            migrationBuilder.DropColumn(
                name: "StageId",
                table: "WasteBills");

            migrationBuilder.DropColumn(
                name: "StageId",
                table: "ReceivedProducts");
		}
    }
}
