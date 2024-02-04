using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Bills : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "uw_product_waste");

            migrationBuilder.DropTable(
                name: "uw_product_way");

            migrationBuilder.DropTable(
                name: "uw_waste_bill");

            migrationBuilder.DropTable(
                name: "uw_way_bill");

            migrationBuilder.DropSequence(
                name: "WasteBillNumbers");

            migrationBuilder.DropSequence(
                name: "WayBillNumbers");

            migrationBuilder.CreateSequence(
                name: "BillNumbers");

            migrationBuilder.CreateTable(
                name: "uw_bill",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<long>(type: "bigint", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false),
                    CarId = table.Column<Guid>(type: "uuid", nullable: true),
                    WarehouseId = table.Column<Guid>(type: "uuid", nullable: false),
                    Note = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    RealizationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ActualRealizationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Number = table.Column<decimal>(type: "numeric(20,0)", nullable: false, defaultValueSql: "nextval('\"BillNumbers\"')"),
                    UwProductStageId = table.Column<Guid>(type: "uuid", nullable: true),
                    ObjectCreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uw_bill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_uw_bill_uw_car_CarId",
                        column: x => x.CarId,
                        principalTable: "uw_car",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_uw_bill_uw_product_stage_UwProductStageId",
                        column: x => x.UwProductStageId,
                        principalTable: "uw_product_stage",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_uw_bill_uw_user_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "uw_user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_uw_bill_uw_warehouse_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "uw_warehouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "uw_product_bill",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    WasteBillId = table.Column<Guid>(type: "uuid", nullable: false),
                    BillId = table.Column<Guid>(type: "uuid", nullable: false),
                    ObjectCreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uw_product_bill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_uw_product_bill_uw_bill_BillId",
                        column: x => x.BillId,
                        principalTable: "uw_bill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_uw_product_bill_uw_product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "uw_product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_uw_bill_CarId",
                table: "uw_bill",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_uw_bill_Number",
                table: "uw_bill",
                column: "Number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_uw_bill_OwnerId",
                table: "uw_bill",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_uw_bill_UwProductStageId",
                table: "uw_bill",
                column: "UwProductStageId");

            migrationBuilder.CreateIndex(
                name: "IX_uw_bill_WarehouseId",
                table: "uw_bill",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_uw_product_bill_BillId",
                table: "uw_product_bill",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_uw_product_bill_ProductId",
                table: "uw_product_bill",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "uw_product_bill");

            migrationBuilder.DropTable(
                name: "uw_bill");

            migrationBuilder.DropSequence(
                name: "BillNumbers");

            migrationBuilder.CreateSequence(
                name: "WasteBillNumbers");

            migrationBuilder.CreateSequence(
                name: "WayBillNumbers");

            migrationBuilder.CreateTable(
                name: "uw_waste_bill",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CarId = table.Column<Guid>(type: "uuid", nullable: true),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false),
                    StageId = table.Column<Guid>(type: "uuid", nullable: false),
                    WarehouseId = table.Column<Guid>(type: "uuid", nullable: false),
                    ActualLeaveAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Barcode = table.Column<string>(type: "text", nullable: false),
                    Number = table.Column<decimal>(type: "numeric(20,0)", nullable: false, defaultValueSql: "nextval('\"WasteBillNumbers\"')"),
                    ObjectCreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Quantity = table.Column<long>(type: "bigint", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    WillLeaveAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uw_waste_bill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_uw_waste_bill_uw_car_CarId",
                        column: x => x.CarId,
                        principalTable: "uw_car",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_uw_waste_bill_uw_product_stage_StageId",
                        column: x => x.StageId,
                        principalTable: "uw_product_stage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_uw_waste_bill_uw_user_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "uw_user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_uw_waste_bill_uw_warehouse_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "uw_warehouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "uw_way_bill",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CarId = table.Column<Guid>(type: "uuid", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false),
                    StageId = table.Column<Guid>(type: "uuid", nullable: false),
                    WarehouseId = table.Column<Guid>(type: "uuid", nullable: false),
                    Barcode = table.Column<string>(type: "text", nullable: false),
                    DateOfArrival = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Note = table.Column<string>(type: "text", nullable: true),
                    Number = table.Column<decimal>(type: "numeric(20,0)", nullable: false, defaultValueSql: "nextval('\"WayBillNumbers\"')"),
                    ObjectCreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Quantity = table.Column<long>(type: "bigint", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uw_way_bill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_uw_way_bill_uw_car_CarId",
                        column: x => x.CarId,
                        principalTable: "uw_car",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_uw_way_bill_uw_product_stage_StageId",
                        column: x => x.StageId,
                        principalTable: "uw_product_stage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_uw_way_bill_uw_user_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "uw_user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_uw_way_bill_uw_warehouse_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "uw_warehouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "uw_product_waste",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ReceivedProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    WasteBillId = table.Column<Guid>(type: "uuid", nullable: false),
                    ObjectCreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Quantity = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uw_product_waste", x => x.Id);
                    table.ForeignKey(
                        name: "FK_uw_product_waste_uw_received_product_ReceivedProductId",
                        column: x => x.ReceivedProductId,
                        principalTable: "uw_received_product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_uw_product_waste_uw_waste_bill_WasteBillId",
                        column: x => x.WasteBillId,
                        principalTable: "uw_waste_bill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "uw_product_way",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    WayBillId = table.Column<Guid>(type: "uuid", nullable: false),
                    ObjectCreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Quantity = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uw_product_way", x => x.Id);
                    table.ForeignKey(
                        name: "FK_uw_product_way_uw_product_way_ProductId",
                        column: x => x.ProductId,
                        principalTable: "uw_product_way",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_uw_product_way_uw_way_bill_WayBillId",
                        column: x => x.WayBillId,
                        principalTable: "uw_way_bill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_uw_product_waste_ReceivedProductId",
                table: "uw_product_waste",
                column: "ReceivedProductId");

            migrationBuilder.CreateIndex(
                name: "IX_uw_product_waste_WasteBillId",
                table: "uw_product_waste",
                column: "WasteBillId");

            migrationBuilder.CreateIndex(
                name: "IX_uw_product_way_ProductId",
                table: "uw_product_way",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_uw_product_way_WayBillId",
                table: "uw_product_way",
                column: "WayBillId");

            migrationBuilder.CreateIndex(
                name: "IX_uw_waste_bill_CarId",
                table: "uw_waste_bill",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_uw_waste_bill_Number",
                table: "uw_waste_bill",
                column: "Number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_uw_waste_bill_OwnerId",
                table: "uw_waste_bill",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_uw_waste_bill_StageId",
                table: "uw_waste_bill",
                column: "StageId");

            migrationBuilder.CreateIndex(
                name: "IX_uw_waste_bill_WarehouseId",
                table: "uw_waste_bill",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_uw_way_bill_CarId",
                table: "uw_way_bill",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_uw_way_bill_Number",
                table: "uw_way_bill",
                column: "Number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_uw_way_bill_OwnerId",
                table: "uw_way_bill",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_uw_way_bill_StageId",
                table: "uw_way_bill",
                column: "StageId");

            migrationBuilder.CreateIndex(
                name: "IX_uw_way_bill_WarehouseId",
                table: "uw_way_bill",
                column: "WarehouseId");
        }
    }
}
