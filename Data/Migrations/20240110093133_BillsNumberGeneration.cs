using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class BillsNumberGeneration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "WasteBillNumbers");

            migrationBuilder.CreateSequence(
                name: "WayBillNumbers");

            migrationBuilder.AlterColumn<decimal>(
                name: "Number",
                table: "WayBills",
                type: "numeric(20,0)",
                nullable: false,
                defaultValueSql: "nextval('\"WayBillNumbers\"')",
                oldClrType: typeof(decimal),
                oldType: "numeric(20,0)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Number",
                table: "WasteBills",
                type: "numeric(20,0)",
                nullable: false,
                defaultValueSql: "nextval('\"WasteBillNumbers\"')",
                oldClrType: typeof(decimal),
                oldType: "numeric(20,0)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropSequence(
                name: "WasteBillNumbers");

            migrationBuilder.DropSequence(
                name: "WayBillNumbers");

            migrationBuilder.AlterColumn<decimal>(
                name: "Number",
                table: "WayBills",
                type: "numeric(20,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(20,0)",
                oldDefaultValueSql: "nextval('\"WayBillNumbers\"')");

            migrationBuilder.AlterColumn<decimal>(
                name: "Number",
                table: "WasteBills",
                type: "numeric(20,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(20,0)",
                oldDefaultValueSql: "nextval('\"WasteBillNumbers\"')");
        }
    }
}
