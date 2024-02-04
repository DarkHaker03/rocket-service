using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
	/// <inheritdoc />
	public partial class TablesRenaming : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
			name: "FK_ReceivedProductActions_ActionTypes_TypeId",
			table: "ReceivedProductActions");

			migrationBuilder.DropPrimaryKey(
				name: "PK_ActionTypes",
				table: "ActionTypes");

			migrationBuilder.RenameTable(
				name: "ActionTypes",
				newName: "uw_action_type");

			migrationBuilder.AddPrimaryKey(
				name: "PK_uw_action_type",
				table: "uw_action_type",
				column: "Id");

			migrationBuilder.AddForeignKey(
				name: "FK_ReceivedProductActions_uw_action_type_TypeId",
				table: "ReceivedProductActions",
				column: "TypeId",
				principalTable: "uw_action_type",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.DropForeignKey(
			   name: "FK_BasketReceivedProductLinks_Baskets_BasketId",
			   table: "BasketReceivedProductLinks");

			migrationBuilder.DropForeignKey(
				name: "FK_BasketReceivedProductLinks_ReceivedProductCells_ReceivedPro~",
				table: "BasketReceivedProductLinks");

			migrationBuilder.DropForeignKey(
				name: "FK_Employees_EmployeeTypes_TypeId",
				table: "Employees");

			migrationBuilder.DropForeignKey(
				name: "FK_Employees_Users_UserId",
				table: "Employees");

			migrationBuilder.DropForeignKey(
				name: "FK_Employees_Warehouses_WarehouseId",
				table: "Employees");

			migrationBuilder.DropForeignKey(
				name: "FK_ReceivedProductActions_Employees_EmployeeId",
				table: "ReceivedProductActions");

			migrationBuilder.DropForeignKey(
				name: "FK_ReceivedProductActions_ReceivedProducts_ReceivedProductId",
				table: "ReceivedProductActions");

			migrationBuilder.DropForeignKey(
				name: "FK_ReceivedProductActions_uw_action_type_TypeId",
				table: "ReceivedProductActions");

			migrationBuilder.DropForeignKey(
				name: "FK_ReceivedProductCells_ReceivedProducts_ReceivedProductId",
				table: "ReceivedProductCells");

			migrationBuilder.DropForeignKey(
				name: "FK_ReceivedProducts_ProductStages_StageId",
				table: "ReceivedProducts");

			migrationBuilder.DropForeignKey(
				name: "FK_ReceivedProducts_Products_ProductId",
				table: "ReceivedProducts");

			migrationBuilder.DropForeignKey(
				name: "FK_ReceivedProducts_Users_OwnerId",
				table: "ReceivedProducts");

			migrationBuilder.DropForeignKey(
				name: "FK_ReceivedProducts_Warehouses_WarehouseId",
				table: "ReceivedProducts");

			migrationBuilder.DropForeignKey(
				name: "FK_WasteBills_Cars_CarId",
				table: "WasteBills");

			migrationBuilder.DropForeignKey(
				name: "FK_WasteBills_ProductStages_StageId",
				table: "WasteBills");

			migrationBuilder.DropForeignKey(
				name: "FK_WasteBills_Products_ProductId",
				table: "WasteBills");

			migrationBuilder.DropForeignKey(
				name: "FK_WasteBills_Users_OwnerId",
				table: "WasteBills");

			migrationBuilder.DropForeignKey(
				name: "FK_WasteBills_Warehouses_WarehouseId",
				table: "WasteBills");

			migrationBuilder.DropForeignKey(
				name: "FK_WayBills_Cars_CarId",
				table: "WayBills");

			migrationBuilder.DropForeignKey(
				name: "FK_WayBills_ProductStages_StageId",
				table: "WayBills");

			migrationBuilder.DropForeignKey(
				name: "FK_WayBills_Products_ProductId",
				table: "WayBills");

			migrationBuilder.DropForeignKey(
				name: "FK_WayBills_Users_OwnerId",
				table: "WayBills");

			migrationBuilder.DropForeignKey(
				name: "FK_WayBills_Warehouses_WarehouseId",
				table: "WayBills");

			migrationBuilder.DropForeignKey(
				name: "FK_WrittenOffReceivedProducts_Employees_EmployeeId",
				table: "WrittenOffReceivedProducts");

			migrationBuilder.DropForeignKey(
				name: "FK_WrittenOffReceivedProducts_ReceivedProducts_ReceivedProduct~",
				table: "WrittenOffReceivedProducts");

			migrationBuilder.DropForeignKey(
				name: "FK_WrittenOffReceivedProducts_WriteOffTypes_TypeId",
				table: "WrittenOffReceivedProducts");

			migrationBuilder.DropPrimaryKey(
				name: "PK_WrittenOffReceivedProducts",
				table: "WrittenOffReceivedProducts");

			migrationBuilder.DropPrimaryKey(
				name: "PK_WriteOffTypes",
				table: "WriteOffTypes");

			migrationBuilder.DropPrimaryKey(
				name: "PK_WayBills",
				table: "WayBills");

			migrationBuilder.DropPrimaryKey(
				name: "PK_WasteBills",
				table: "WasteBills");

			migrationBuilder.DropPrimaryKey(
				name: "PK_Warehouses",
				table: "Warehouses");

			migrationBuilder.DropPrimaryKey(
				name: "PK_Users",
				table: "Users");

			migrationBuilder.DropPrimaryKey(
				name: "PK_ReceivedProducts",
				table: "ReceivedProducts");

			migrationBuilder.DropPrimaryKey(
				name: "PK_ReceivedProductCells",
				table: "ReceivedProductCells");

			migrationBuilder.DropPrimaryKey(
				name: "PK_ReceivedProductActions",
				table: "ReceivedProductActions");

			migrationBuilder.DropPrimaryKey(
				name: "PK_Products",
				table: "Products");

			migrationBuilder.DropPrimaryKey(
				name: "PK_ProductStages",
				table: "ProductStages");

			migrationBuilder.DropPrimaryKey(
				name: "PK_Employees",
				table: "Employees");

			migrationBuilder.DropPrimaryKey(
				name: "PK_EmployeeTypes",
				table: "EmployeeTypes");

			migrationBuilder.DropPrimaryKey(
				name: "PK_Cars",
				table: "Cars");

			migrationBuilder.DropPrimaryKey(
				name: "PK_Baskets",
				table: "Baskets");

			migrationBuilder.DropPrimaryKey(
				name: "PK_BasketReceivedProductLinks",
				table: "BasketReceivedProductLinks");

			migrationBuilder.RenameTable(
				name: "WrittenOffReceivedProducts",
				newName: "uw_written_off_received_product");

			migrationBuilder.RenameTable(
				name: "WriteOffTypes",
				newName: "uw_write_off_type");

			migrationBuilder.RenameTable(
				name: "WayBills",
				newName: "uw_way_bill");

			migrationBuilder.RenameTable(
				name: "WasteBills",
				newName: "uw_waste_bill");

			migrationBuilder.RenameTable(
				name: "Warehouses",
				newName: "uw_warehouse");

			migrationBuilder.RenameTable(
				name: "Users",
				newName: "uw_user");

			migrationBuilder.RenameTable(
				name: "ReceivedProducts",
				newName: "uw_received_product");

			migrationBuilder.RenameTable(
				name: "ReceivedProductCells",
				newName: "uw_received_product_cell");

			migrationBuilder.RenameTable(
				name: "ReceivedProductActions",
				newName: "uw_received_product_action");

			migrationBuilder.RenameTable(
				name: "Products",
				newName: "uw_product");

			migrationBuilder.RenameTable(
				name: "ProductStages",
				newName: "uw_product_stage");

			migrationBuilder.RenameTable(
				name: "Employees",
				newName: "uw_employee");

			migrationBuilder.RenameTable(
				name: "EmployeeTypes",
				newName: "employee_type");

			migrationBuilder.RenameTable(
				name: "Cars",
				newName: "uw_car");

			migrationBuilder.RenameTable(
				name: "Baskets",
				newName: "uw_basket");

			migrationBuilder.RenameTable(
				name: "BasketReceivedProductLinks",
				newName: "uw_basket_received_product_link");

			migrationBuilder.RenameIndex(
				name: "IX_WrittenOffReceivedProducts_TypeId",
				table: "uw_written_off_received_product",
				newName: "IX_uw_written_off_received_product_TypeId");

			migrationBuilder.RenameIndex(
				name: "IX_WrittenOffReceivedProducts_ReceivedProductId",
				table: "uw_written_off_received_product",
				newName: "IX_uw_written_off_received_product_ReceivedProductId");

			migrationBuilder.RenameIndex(
				name: "IX_WrittenOffReceivedProducts_EmployeeId",
				table: "uw_written_off_received_product",
				newName: "IX_uw_written_off_received_product_EmployeeId");

			migrationBuilder.RenameIndex(
				name: "IX_WayBills_WarehouseId",
				table: "uw_way_bill",
				newName: "IX_uw_way_bill_WarehouseId");

			migrationBuilder.RenameIndex(
				name: "IX_WayBills_StageId",
				table: "uw_way_bill",
				newName: "IX_uw_way_bill_StageId");

			migrationBuilder.RenameIndex(
				name: "IX_WayBills_ProductId",
				table: "uw_way_bill",
				newName: "IX_uw_way_bill_ProductId");

			migrationBuilder.RenameIndex(
				name: "IX_WayBills_OwnerId",
				table: "uw_way_bill",
				newName: "IX_uw_way_bill_OwnerId");

			migrationBuilder.RenameIndex(
				name: "IX_WayBills_Number",
				table: "uw_way_bill",
				newName: "IX_uw_way_bill_Number");

			migrationBuilder.RenameIndex(
				name: "IX_WayBills_CarId",
				table: "uw_way_bill",
				newName: "IX_uw_way_bill_CarId");

			migrationBuilder.RenameIndex(
				name: "IX_WasteBills_WarehouseId",
				table: "uw_waste_bill",
				newName: "IX_uw_waste_bill_WarehouseId");

			migrationBuilder.RenameIndex(
				name: "IX_WasteBills_StageId",
				table: "uw_waste_bill",
				newName: "IX_uw_waste_bill_StageId");

			migrationBuilder.RenameIndex(
				name: "IX_WasteBills_ProductId",
				table: "uw_waste_bill",
				newName: "IX_uw_waste_bill_ProductId");

			migrationBuilder.RenameIndex(
				name: "IX_WasteBills_OwnerId",
				table: "uw_waste_bill",
				newName: "IX_uw_waste_bill_OwnerId");

			migrationBuilder.RenameIndex(
				name: "IX_WasteBills_Number",
				table: "uw_waste_bill",
				newName: "IX_uw_waste_bill_Number");

			migrationBuilder.RenameIndex(
				name: "IX_WasteBills_CarId",
				table: "uw_waste_bill",
				newName: "IX_uw_waste_bill_CarId");

			migrationBuilder.RenameIndex(
				name: "IX_Users_Email",
				table: "uw_user",
				newName: "IX_uw_user_Email");

			migrationBuilder.RenameIndex(
				name: "IX_ReceivedProducts_WarehouseId",
				table: "uw_received_product",
				newName: "IX_uw_received_product_WarehouseId");

			migrationBuilder.RenameIndex(
				name: "IX_ReceivedProducts_StageId",
				table: "uw_received_product",
				newName: "IX_uw_received_product_StageId");

			migrationBuilder.RenameIndex(
				name: "IX_ReceivedProducts_ProductId",
				table: "uw_received_product",
				newName: "IX_uw_received_product_ProductId");

			migrationBuilder.RenameIndex(
				name: "IX_ReceivedProducts_OwnerId",
				table: "uw_received_product",
				newName: "IX_uw_received_product_OwnerId");

			migrationBuilder.RenameIndex(
				name: "IX_ReceivedProductCells_ReceivedProductId",
				table: "uw_received_product_cell",
				newName: "IX_uw_received_product_cell_ReceivedProductId");

			migrationBuilder.RenameIndex(
				name: "IX_ReceivedProductActions_TypeId",
				table: "uw_received_product_action",
				newName: "IX_uw_received_product_action_TypeId");

			migrationBuilder.RenameIndex(
				name: "IX_ReceivedProductActions_ReceivedProductId",
				table: "uw_received_product_action",
				newName: "IX_uw_received_product_action_ReceivedProductId");

			migrationBuilder.RenameIndex(
				name: "IX_ReceivedProductActions_EmployeeId",
				table: "uw_received_product_action",
				newName: "IX_uw_received_product_action_EmployeeId");

			migrationBuilder.RenameIndex(
				name: "IX_Employees_WarehouseId",
				table: "uw_employee",
				newName: "IX_uw_employee_WarehouseId");

			migrationBuilder.RenameIndex(
				name: "IX_Employees_UserId",
				table: "uw_employee",
				newName: "IX_uw_employee_UserId");

			migrationBuilder.RenameIndex(
				name: "IX_Employees_TypeId",
				table: "uw_employee",
				newName: "IX_uw_employee_TypeId");

			migrationBuilder.RenameIndex(
				name: "IX_BasketReceivedProductLinks_ReceivedProductCellId",
				table: "uw_basket_received_product_link",
				newName: "IX_uw_basket_received_product_link_ReceivedProductCellId");

			migrationBuilder.RenameIndex(
				name: "IX_BasketReceivedProductLinks_BasketId",
				table: "uw_basket_received_product_link",
				newName: "IX_uw_basket_received_product_link_BasketId");

			migrationBuilder.AddPrimaryKey(
				name: "PK_uw_written_off_received_product",
				table: "uw_written_off_received_product",
				column: "Id");

			migrationBuilder.AddPrimaryKey(
				name: "PK_uw_write_off_type",
				table: "uw_write_off_type",
				column: "Id");

			migrationBuilder.AddPrimaryKey(
				name: "PK_uw_way_bill",
				table: "uw_way_bill",
				column: "Id");

			migrationBuilder.AddPrimaryKey(
				name: "PK_uw_waste_bill",
				table: "uw_waste_bill",
				column: "Id");

			migrationBuilder.AddPrimaryKey(
				name: "PK_uw_warehouse",
				table: "uw_warehouse",
				column: "Id");

			migrationBuilder.AddPrimaryKey(
				name: "PK_uw_user",
				table: "uw_user",
				column: "Id");

			migrationBuilder.AddPrimaryKey(
				name: "PK_uw_received_product",
				table: "uw_received_product",
				column: "Id");

			migrationBuilder.AddPrimaryKey(
				name: "PK_uw_received_product_cell",
				table: "uw_received_product_cell",
				column: "Id");

			migrationBuilder.AddPrimaryKey(
				name: "PK_uw_received_product_action",
				table: "uw_received_product_action",
				column: "Id");

			migrationBuilder.AddPrimaryKey(
				name: "PK_uw_product",
				table: "uw_product",
				column: "Id");

			migrationBuilder.AddPrimaryKey(
				name: "PK_uw_product_stage",
				table: "uw_product_stage",
				column: "Id");

			migrationBuilder.AddPrimaryKey(
				name: "PK_uw_employee",
				table: "uw_employee",
				column: "Id");

			migrationBuilder.AddPrimaryKey(
				name: "PK_employee_type",
				table: "employee_type",
				column: "Id");

			migrationBuilder.AddPrimaryKey(
				name: "PK_uw_car",
				table: "uw_car",
				column: "Id");

			migrationBuilder.AddPrimaryKey(
				name: "PK_uw_basket",
				table: "uw_basket",
				column: "Id");

			migrationBuilder.AddPrimaryKey(
				name: "PK_uw_basket_received_product_link",
				table: "uw_basket_received_product_link",
				column: "Id");

			migrationBuilder.AddForeignKey(
				name: "FK_uw_basket_received_product_link_uw_basket_BasketId",
				table: "uw_basket_received_product_link",
				column: "BasketId",
				principalTable: "uw_basket",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_uw_basket_received_product_link_uw_received_product_cell_Re~",
				table: "uw_basket_received_product_link",
				column: "ReceivedProductCellId",
				principalTable: "uw_received_product_cell",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_uw_employee_employee_type_TypeId",
				table: "uw_employee",
				column: "TypeId",
				principalTable: "employee_type",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_uw_employee_uw_user_UserId",
				table: "uw_employee",
				column: "UserId",
				principalTable: "uw_user",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_uw_employee_uw_warehouse_WarehouseId",
				table: "uw_employee",
				column: "WarehouseId",
				principalTable: "uw_warehouse",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_uw_received_product_uw_product_ProductId",
				table: "uw_received_product",
				column: "ProductId",
				principalTable: "uw_product",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_uw_received_product_uw_product_stage_StageId",
				table: "uw_received_product",
				column: "StageId",
				principalTable: "uw_product_stage",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_uw_received_product_uw_user_OwnerId",
				table: "uw_received_product",
				column: "OwnerId",
				principalTable: "uw_user",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_uw_received_product_uw_warehouse_WarehouseId",
				table: "uw_received_product",
				column: "WarehouseId",
				principalTable: "uw_warehouse",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_uw_received_product_action_uw_action_type_TypeId",
				table: "uw_received_product_action",
				column: "TypeId",
				principalTable: "uw_action_type",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_uw_received_product_action_uw_employee_EmployeeId",
				table: "uw_received_product_action",
				column: "EmployeeId",
				principalTable: "uw_employee",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_uw_received_product_action_uw_received_product_ReceivedProd~",
				table: "uw_received_product_action",
				column: "ReceivedProductId",
				principalTable: "uw_received_product",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_uw_received_product_cell_uw_received_product_ReceivedProduc~",
				table: "uw_received_product_cell",
				column: "ReceivedProductId",
				principalTable: "uw_received_product",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_uw_waste_bill_uw_car_CarId",
				table: "uw_waste_bill",
				column: "CarId",
				principalTable: "uw_car",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_uw_waste_bill_uw_product_ProductId",
				table: "uw_waste_bill",
				column: "ProductId",
				principalTable: "uw_product",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_uw_waste_bill_uw_product_stage_StageId",
				table: "uw_waste_bill",
				column: "StageId",
				principalTable: "uw_product_stage",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_uw_waste_bill_uw_user_OwnerId",
				table: "uw_waste_bill",
				column: "OwnerId",
				principalTable: "uw_user",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_uw_waste_bill_uw_warehouse_WarehouseId",
				table: "uw_waste_bill",
				column: "WarehouseId",
				principalTable: "uw_warehouse",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_uw_way_bill_uw_car_CarId",
				table: "uw_way_bill",
				column: "CarId",
				principalTable: "uw_car",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_uw_way_bill_uw_product_ProductId",
				table: "uw_way_bill",
				column: "ProductId",
				principalTable: "uw_product",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_uw_way_bill_uw_product_stage_StageId",
				table: "uw_way_bill",
				column: "StageId",
				principalTable: "uw_product_stage",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_uw_way_bill_uw_user_OwnerId",
				table: "uw_way_bill",
				column: "OwnerId",
				principalTable: "uw_user",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_uw_way_bill_uw_warehouse_WarehouseId",
				table: "uw_way_bill",
				column: "WarehouseId",
				principalTable: "uw_warehouse",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_uw_written_off_received_product_uw_employee_EmployeeId",
				table: "uw_written_off_received_product",
				column: "EmployeeId",
				principalTable: "uw_employee",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_uw_written_off_received_product_uw_received_product_Receive~",
				table: "uw_written_off_received_product",
				column: "ReceivedProductId",
				principalTable: "uw_received_product",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_uw_written_off_received_product_uw_write_off_type_TypeId",
				table: "uw_written_off_received_product",
				column: "TypeId",
				principalTable: "uw_write_off_type",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_ReceivedProductActions_uw_action_type_TypeId",
				table: "ReceivedProductActions");

			migrationBuilder.DropPrimaryKey(
				name: "PK_uw_action_type",
				table: "uw_action_type");

			migrationBuilder.RenameTable(
				name: "uw_action_type",
				newName: "ActionTypes");

			migrationBuilder.AddPrimaryKey(
				name: "PK_ActionTypes",
				table: "ActionTypes",
				column: "Id");

			migrationBuilder.AddForeignKey(
				name: "FK_ReceivedProductActions_ActionTypes_TypeId",
				table: "ReceivedProductActions",
				column: "TypeId",
				principalTable: "ActionTypes",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.DropForeignKey(
			  name: "FK_uw_basket_received_product_link_uw_basket_BasketId",
			  table: "uw_basket_received_product_link");

			migrationBuilder.DropForeignKey(
				name: "FK_uw_basket_received_product_link_uw_received_product_cell_Re~",
				table: "uw_basket_received_product_link");

			migrationBuilder.DropForeignKey(
				name: "FK_uw_employee_employee_type_TypeId",
				table: "uw_employee");

			migrationBuilder.DropForeignKey(
				name: "FK_uw_employee_uw_user_UserId",
				table: "uw_employee");

			migrationBuilder.DropForeignKey(
				name: "FK_uw_employee_uw_warehouse_WarehouseId",
				table: "uw_employee");

			migrationBuilder.DropForeignKey(
				name: "FK_uw_received_product_uw_product_ProductId",
				table: "uw_received_product");

			migrationBuilder.DropForeignKey(
				name: "FK_uw_received_product_uw_product_stage_StageId",
				table: "uw_received_product");

			migrationBuilder.DropForeignKey(
				name: "FK_uw_received_product_uw_user_OwnerId",
				table: "uw_received_product");

			migrationBuilder.DropForeignKey(
				name: "FK_uw_received_product_uw_warehouse_WarehouseId",
				table: "uw_received_product");

			migrationBuilder.DropForeignKey(
				name: "FK_uw_received_product_action_uw_action_type_TypeId",
				table: "uw_received_product_action");

			migrationBuilder.DropForeignKey(
				name: "FK_uw_received_product_action_uw_employee_EmployeeId",
				table: "uw_received_product_action");

			migrationBuilder.DropForeignKey(
				name: "FK_uw_received_product_action_uw_received_product_ReceivedProd~",
				table: "uw_received_product_action");

			migrationBuilder.DropForeignKey(
				name: "FK_uw_received_product_cell_uw_received_product_ReceivedProduc~",
				table: "uw_received_product_cell");

			migrationBuilder.DropForeignKey(
				name: "FK_uw_waste_bill_uw_car_CarId",
				table: "uw_waste_bill");

			migrationBuilder.DropForeignKey(
				name: "FK_uw_waste_bill_uw_product_ProductId",
				table: "uw_waste_bill");

			migrationBuilder.DropForeignKey(
				name: "FK_uw_waste_bill_uw_product_stage_StageId",
				table: "uw_waste_bill");

			migrationBuilder.DropForeignKey(
				name: "FK_uw_waste_bill_uw_user_OwnerId",
				table: "uw_waste_bill");

			migrationBuilder.DropForeignKey(
				name: "FK_uw_waste_bill_uw_warehouse_WarehouseId",
				table: "uw_waste_bill");

			migrationBuilder.DropForeignKey(
				name: "FK_uw_way_bill_uw_car_CarId",
				table: "uw_way_bill");

			migrationBuilder.DropForeignKey(
				name: "FK_uw_way_bill_uw_product_ProductId",
				table: "uw_way_bill");

			migrationBuilder.DropForeignKey(
				name: "FK_uw_way_bill_uw_product_stage_StageId",
				table: "uw_way_bill");

			migrationBuilder.DropForeignKey(
				name: "FK_uw_way_bill_uw_user_OwnerId",
				table: "uw_way_bill");

			migrationBuilder.DropForeignKey(
				name: "FK_uw_way_bill_uw_warehouse_WarehouseId",
				table: "uw_way_bill");

			migrationBuilder.DropForeignKey(
				name: "FK_uw_written_off_received_product_uw_employee_EmployeeId",
				table: "uw_written_off_received_product");

			migrationBuilder.DropForeignKey(
				name: "FK_uw_written_off_received_product_uw_received_product_Receive~",
				table: "uw_written_off_received_product");

			migrationBuilder.DropForeignKey(
				name: "FK_uw_written_off_received_product_uw_write_off_type_TypeId",
				table: "uw_written_off_received_product");

			migrationBuilder.DropPrimaryKey(
				name: "PK_uw_written_off_received_product",
				table: "uw_written_off_received_product");

			migrationBuilder.DropPrimaryKey(
				name: "PK_uw_write_off_type",
				table: "uw_write_off_type");

			migrationBuilder.DropPrimaryKey(
				name: "PK_uw_way_bill",
				table: "uw_way_bill");

			migrationBuilder.DropPrimaryKey(
				name: "PK_uw_waste_bill",
				table: "uw_waste_bill");

			migrationBuilder.DropPrimaryKey(
				name: "PK_uw_warehouse",
				table: "uw_warehouse");

			migrationBuilder.DropPrimaryKey(
				name: "PK_uw_user",
				table: "uw_user");

			migrationBuilder.DropPrimaryKey(
				name: "PK_uw_received_product_cell",
				table: "uw_received_product_cell");

			migrationBuilder.DropPrimaryKey(
				name: "PK_uw_received_product_action",
				table: "uw_received_product_action");

			migrationBuilder.DropPrimaryKey(
				name: "PK_uw_received_product",
				table: "uw_received_product");

			migrationBuilder.DropPrimaryKey(
				name: "PK_uw_product_stage",
				table: "uw_product_stage");

			migrationBuilder.DropPrimaryKey(
				name: "PK_uw_product",
				table: "uw_product");

			migrationBuilder.DropPrimaryKey(
				name: "PK_uw_employee",
				table: "uw_employee");

			migrationBuilder.DropPrimaryKey(
				name: "PK_uw_car",
				table: "uw_car");

			migrationBuilder.DropPrimaryKey(
				name: "PK_uw_basket_received_product_link",
				table: "uw_basket_received_product_link");

			migrationBuilder.DropPrimaryKey(
				name: "PK_uw_basket",
				table: "uw_basket");

			migrationBuilder.DropPrimaryKey(
				name: "PK_employee_type",
				table: "employee_type");

			migrationBuilder.RenameTable(
				name: "uw_written_off_received_product",
				newName: "WrittenOffReceivedProducts");

			migrationBuilder.RenameTable(
				name: "uw_write_off_type",
				newName: "WriteOffTypes");

			migrationBuilder.RenameTable(
				name: "uw_way_bill",
				newName: "WayBills");

			migrationBuilder.RenameTable(
				name: "uw_waste_bill",
				newName: "WasteBills");

			migrationBuilder.RenameTable(
				name: "uw_warehouse",
				newName: "Warehouses");

			migrationBuilder.RenameTable(
				name: "uw_user",
				newName: "Users");

			migrationBuilder.RenameTable(
				name: "uw_received_product_cell",
				newName: "ReceivedProductCells");

			migrationBuilder.RenameTable(
				name: "uw_received_product_action",
				newName: "ReceivedProductActions");

			migrationBuilder.RenameTable(
				name: "uw_received_product",
				newName: "ReceivedProducts");

			migrationBuilder.RenameTable(
				name: "uw_product_stage",
				newName: "ProductStages");

			migrationBuilder.RenameTable(
				name: "uw_product",
				newName: "Products");

			migrationBuilder.RenameTable(
				name: "uw_employee",
				newName: "Employees");

			migrationBuilder.RenameTable(
				name: "uw_car",
				newName: "Cars");

			migrationBuilder.RenameTable(
				name: "uw_basket_received_product_link",
				newName: "BasketReceivedProductLinks");

			migrationBuilder.RenameTable(
				name: "uw_basket",
				newName: "Baskets");

			migrationBuilder.RenameTable(
				name: "employee_type",
				newName: "EmployeeTypes");

			migrationBuilder.RenameIndex(
				name: "IX_uw_written_off_received_product_TypeId",
				table: "WrittenOffReceivedProducts",
				newName: "IX_WrittenOffReceivedProducts_TypeId");

			migrationBuilder.RenameIndex(
				name: "IX_uw_written_off_received_product_ReceivedProductId",
				table: "WrittenOffReceivedProducts",
				newName: "IX_WrittenOffReceivedProducts_ReceivedProductId");

			migrationBuilder.RenameIndex(
				name: "IX_uw_written_off_received_product_EmployeeId",
				table: "WrittenOffReceivedProducts",
				newName: "IX_WrittenOffReceivedProducts_EmployeeId");

			migrationBuilder.RenameIndex(
				name: "IX_uw_way_bill_WarehouseId",
				table: "WayBills",
				newName: "IX_WayBills_WarehouseId");

			migrationBuilder.RenameIndex(
				name: "IX_uw_way_bill_StageId",
				table: "WayBills",
				newName: "IX_WayBills_StageId");

			migrationBuilder.RenameIndex(
				name: "IX_uw_way_bill_ProductId",
				table: "WayBills",
				newName: "IX_WayBills_ProductId");

			migrationBuilder.RenameIndex(
				name: "IX_uw_way_bill_OwnerId",
				table: "WayBills",
				newName: "IX_WayBills_OwnerId");

			migrationBuilder.RenameIndex(
				name: "IX_uw_way_bill_Number",
				table: "WayBills",
				newName: "IX_WayBills_Number");

			migrationBuilder.RenameIndex(
				name: "IX_uw_way_bill_CarId",
				table: "WayBills",
				newName: "IX_WayBills_CarId");

			migrationBuilder.RenameIndex(
				name: "IX_uw_waste_bill_WarehouseId",
				table: "WasteBills",
				newName: "IX_WasteBills_WarehouseId");

			migrationBuilder.RenameIndex(
				name: "IX_uw_waste_bill_StageId",
				table: "WasteBills",
				newName: "IX_WasteBills_StageId");

			migrationBuilder.RenameIndex(
				name: "IX_uw_waste_bill_ProductId",
				table: "WasteBills",
				newName: "IX_WasteBills_ProductId");

			migrationBuilder.RenameIndex(
				name: "IX_uw_waste_bill_OwnerId",
				table: "WasteBills",
				newName: "IX_WasteBills_OwnerId");

			migrationBuilder.RenameIndex(
				name: "IX_uw_waste_bill_Number",
				table: "WasteBills",
				newName: "IX_WasteBills_Number");

			migrationBuilder.RenameIndex(
				name: "IX_uw_waste_bill_CarId",
				table: "WasteBills",
				newName: "IX_WasteBills_CarId");

			migrationBuilder.RenameIndex(
				name: "IX_uw_user_Email",
				table: "Users",
				newName: "IX_Users_Email");

			migrationBuilder.RenameIndex(
				name: "IX_uw_received_product_cell_ReceivedProductId",
				table: "ReceivedProductCells",
				newName: "IX_ReceivedProductCells_ReceivedProductId");

			migrationBuilder.RenameIndex(
				name: "IX_uw_received_product_action_TypeId",
				table: "ReceivedProductActions",
				newName: "IX_ReceivedProductActions_TypeId");

			migrationBuilder.RenameIndex(
				name: "IX_uw_received_product_action_ReceivedProductId",
				table: "ReceivedProductActions",
				newName: "IX_ReceivedProductActions_ReceivedProductId");

			migrationBuilder.RenameIndex(
				name: "IX_uw_received_product_action_EmployeeId",
				table: "ReceivedProductActions",
				newName: "IX_ReceivedProductActions_EmployeeId");

			migrationBuilder.RenameIndex(
				name: "IX_uw_received_product_WarehouseId",
				table: "ReceivedProducts",
				newName: "IX_ReceivedProducts_WarehouseId");

			migrationBuilder.RenameIndex(
				name: "IX_uw_received_product_StageId",
				table: "ReceivedProducts",
				newName: "IX_ReceivedProducts_StageId");

			migrationBuilder.RenameIndex(
				name: "IX_uw_received_product_ProductId",
				table: "ReceivedProducts",
				newName: "IX_ReceivedProducts_ProductId");

			migrationBuilder.RenameIndex(
				name: "IX_uw_received_product_OwnerId",
				table: "ReceivedProducts",
				newName: "IX_ReceivedProducts_OwnerId");

			migrationBuilder.RenameIndex(
				name: "IX_uw_employee_WarehouseId",
				table: "Employees",
				newName: "IX_Employees_WarehouseId");

			migrationBuilder.RenameIndex(
				name: "IX_uw_employee_UserId",
				table: "Employees",
				newName: "IX_Employees_UserId");

			migrationBuilder.RenameIndex(
				name: "IX_uw_employee_TypeId",
				table: "Employees",
				newName: "IX_Employees_TypeId");

			migrationBuilder.RenameIndex(
				name: "IX_uw_basket_received_product_link_ReceivedProductCellId",
				table: "BasketReceivedProductLinks",
				newName: "IX_BasketReceivedProductLinks_ReceivedProductCellId");

			migrationBuilder.RenameIndex(
				name: "IX_uw_basket_received_product_link_BasketId",
				table: "BasketReceivedProductLinks",
				newName: "IX_BasketReceivedProductLinks_BasketId");

			migrationBuilder.AddPrimaryKey(
				name: "PK_WrittenOffReceivedProducts",
				table: "WrittenOffReceivedProducts",
				column: "Id");

			migrationBuilder.AddPrimaryKey(
				name: "PK_WriteOffTypes",
				table: "WriteOffTypes",
				column: "Id");

			migrationBuilder.AddPrimaryKey(
				name: "PK_WayBills",
				table: "WayBills",
				column: "Id");

			migrationBuilder.AddPrimaryKey(
				name: "PK_WasteBills",
				table: "WasteBills",
				column: "Id");

			migrationBuilder.AddPrimaryKey(
				name: "PK_Warehouses",
				table: "Warehouses",
				column: "Id");

			migrationBuilder.AddPrimaryKey(
				name: "PK_Users",
				table: "Users",
				column: "Id");

			migrationBuilder.AddPrimaryKey(
				name: "PK_ReceivedProductCells",
				table: "ReceivedProductCells",
				column: "Id");

			migrationBuilder.AddPrimaryKey(
				name: "PK_ReceivedProductActions",
				table: "ReceivedProductActions",
				column: "Id");

			migrationBuilder.AddPrimaryKey(
				name: "PK_ReceivedProducts",
				table: "ReceivedProducts",
				column: "Id");

			migrationBuilder.AddPrimaryKey(
				name: "PK_ProductStages",
				table: "ProductStages",
				column: "Id");

			migrationBuilder.AddPrimaryKey(
				name: "PK_Products",
				table: "Products",
				column: "Id");

			migrationBuilder.AddPrimaryKey(
				name: "PK_Employees",
				table: "Employees",
				column: "Id");

			migrationBuilder.AddPrimaryKey(
				name: "PK_Cars",
				table: "Cars",
				column: "Id");

			migrationBuilder.AddPrimaryKey(
				name: "PK_BasketReceivedProductLinks",
				table: "BasketReceivedProductLinks",
				column: "Id");

			migrationBuilder.AddPrimaryKey(
				name: "PK_Baskets",
				table: "Baskets",
				column: "Id");

			migrationBuilder.AddPrimaryKey(
				name: "PK_EmployeeTypes",
				table: "EmployeeTypes",
				column: "Id");

			migrationBuilder.AddForeignKey(
				name: "FK_BasketReceivedProductLinks_Baskets_BasketId",
				table: "BasketReceivedProductLinks",
				column: "BasketId",
				principalTable: "Baskets",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_BasketReceivedProductLinks_ReceivedProductCells_ReceivedPro~",
				table: "BasketReceivedProductLinks",
				column: "ReceivedProductCellId",
				principalTable: "ReceivedProductCells",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_Employees_EmployeeTypes_TypeId",
				table: "Employees",
				column: "TypeId",
				principalTable: "EmployeeTypes",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_Employees_Users_UserId",
				table: "Employees",
				column: "UserId",
				principalTable: "Users",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_Employees_Warehouses_WarehouseId",
				table: "Employees",
				column: "WarehouseId",
				principalTable: "Warehouses",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_ReceivedProductActions_Employees_EmployeeId",
				table: "ReceivedProductActions",
				column: "EmployeeId",
				principalTable: "Employees",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_ReceivedProductActions_ReceivedProducts_ReceivedProductId",
				table: "ReceivedProductActions",
				column: "ReceivedProductId",
				principalTable: "ReceivedProducts",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_ReceivedProductActions_uw_action_type_TypeId",
				table: "ReceivedProductActions",
				column: "TypeId",
				principalTable: "uw_action_type",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_ReceivedProductCells_ReceivedProducts_ReceivedProductId",
				table: "ReceivedProductCells",
				column: "ReceivedProductId",
				principalTable: "ReceivedProducts",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_ReceivedProducts_ProductStages_StageId",
				table: "ReceivedProducts",
				column: "StageId",
				principalTable: "ProductStages",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_ReceivedProducts_Products_ProductId",
				table: "ReceivedProducts",
				column: "ProductId",
				principalTable: "Products",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_ReceivedProducts_Users_OwnerId",
				table: "ReceivedProducts",
				column: "OwnerId",
				principalTable: "Users",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_ReceivedProducts_Warehouses_WarehouseId",
				table: "ReceivedProducts",
				column: "WarehouseId",
				principalTable: "Warehouses",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_WasteBills_Cars_CarId",
				table: "WasteBills",
				column: "CarId",
				principalTable: "Cars",
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
				name: "FK_WasteBills_Products_ProductId",
				table: "WasteBills",
				column: "ProductId",
				principalTable: "Products",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_WasteBills_Users_OwnerId",
				table: "WasteBills",
				column: "OwnerId",
				principalTable: "Users",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_WasteBills_Warehouses_WarehouseId",
				table: "WasteBills",
				column: "WarehouseId",
				principalTable: "Warehouses",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_WayBills_Cars_CarId",
				table: "WayBills",
				column: "CarId",
				principalTable: "Cars",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_WayBills_ProductStages_StageId",
				table: "WayBills",
				column: "StageId",
				principalTable: "ProductStages",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_WayBills_Products_ProductId",
				table: "WayBills",
				column: "ProductId",
				principalTable: "Products",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_WayBills_Users_OwnerId",
				table: "WayBills",
				column: "OwnerId",
				principalTable: "Users",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_WayBills_Warehouses_WarehouseId",
				table: "WayBills",
				column: "WarehouseId",
				principalTable: "Warehouses",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_WrittenOffReceivedProducts_Employees_EmployeeId",
				table: "WrittenOffReceivedProducts",
				column: "EmployeeId",
				principalTable: "Employees",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_WrittenOffReceivedProducts_ReceivedProducts_ReceivedProduct~",
				table: "WrittenOffReceivedProducts",
				column: "ReceivedProductId",
				principalTable: "ReceivedProducts",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_WrittenOffReceivedProducts_WriteOffTypes_TypeId",
				table: "WrittenOffReceivedProducts",
				column: "TypeId",
				principalTable: "WriteOffTypes",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);
		}
	}
}
