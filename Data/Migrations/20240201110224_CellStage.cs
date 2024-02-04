using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class CellStage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_uw_bill_uw_product_stage_UwProductStageId",
                table: "uw_bill");

            migrationBuilder.DropForeignKey(
                name: "FK_uw_received_product_uw_product_stage_StageId",
                table: "uw_received_product");

            migrationBuilder.DropIndex(
                name: "IX_uw_received_product_StageId",
                table: "uw_received_product");

            migrationBuilder.DropIndex(
                name: "IX_uw_bill_UwProductStageId",
                table: "uw_bill");

            migrationBuilder.DropColumn(
                name: "UwProductStageId",
                table: "uw_bill");

            migrationBuilder.AddColumn<Guid>(
                name: "StageId",
                table: "uw_cell",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_uw_cell_StageId",
                table: "uw_cell",
                column: "StageId");

            migrationBuilder.AddForeignKey(
                name: "FK_uw_cell_uw_product_stage_StageId",
                table: "uw_cell",
                column: "StageId",
                principalTable: "uw_product_stage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_uw_cell_uw_product_stage_StageId",
                table: "uw_cell");

            migrationBuilder.DropIndex(
                name: "IX_uw_cell_StageId",
                table: "uw_cell");

            migrationBuilder.DropColumn(
                name: "StageId",
                table: "uw_cell");

            migrationBuilder.AddColumn<Guid>(
                name: "UwProductStageId",
                table: "uw_bill",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_uw_received_product_StageId",
                table: "uw_received_product",
                column: "StageId");

            migrationBuilder.CreateIndex(
                name: "IX_uw_bill_UwProductStageId",
                table: "uw_bill",
                column: "UwProductStageId");

            migrationBuilder.AddForeignKey(
                name: "FK_uw_bill_uw_product_stage_UwProductStageId",
                table: "uw_bill",
                column: "UwProductStageId",
                principalTable: "uw_product_stage",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_uw_received_product_uw_product_stage_StageId",
                table: "uw_received_product",
                column: "StageId",
                principalTable: "uw_product_stage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
