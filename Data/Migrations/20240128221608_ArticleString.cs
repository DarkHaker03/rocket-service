using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class ArticleString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_uw_waste_bill_uw_car_CarId",
                table: "uw_waste_bill");

            migrationBuilder.AlterColumn<Guid>(
                name: "CarId",
                table: "uw_waste_bill",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "Article",
                table: "uw_product",
                type: "text",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_uw_waste_bill_uw_car_CarId",
                table: "uw_waste_bill",
                column: "CarId",
                principalTable: "uw_car",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_uw_waste_bill_uw_car_CarId",
                table: "uw_waste_bill");

            migrationBuilder.AlterColumn<Guid>(
                name: "CarId",
                table: "uw_waste_bill",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Article",
                table: "uw_product",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_uw_waste_bill_uw_car_CarId",
                table: "uw_waste_bill",
                column: "CarId",
                principalTable: "uw_car",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
