﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(UWDbContext))]
    [Migration("20240128191217_Images")]
    partial class Images
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.HasSequence("WasteBillNumbers");

            modelBuilder.HasSequence("WayBillNumbers");

            modelBuilder.Entity("Domain.Entities.UwActionType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ObjectCreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("uw_action_type");
                });

            modelBuilder.Entity("Domain.Entities.UwBasket", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Barcode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Cell")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("ObjectCreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("uw_basket");
                });

            modelBuilder.Entity("Domain.Entities.UwBasketReceivedProductLink", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BasketId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ObjectCreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("ReceivedProductCellId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("BasketId");

                    b.HasIndex("ReceivedProductCellId");

                    b.ToTable("uw_basket_received_product_link");
                });

            modelBuilder.Entity("Domain.Entities.UwCar", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("ObjectCreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("uw_car");
                });

            modelBuilder.Entity("Domain.Entities.UwCell", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CreatedByEmployeeId")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("ObjectCreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Place")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<Guid>("WarehouseId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CreatedByEmployeeId");

                    b.HasIndex("WarehouseId");

                    b.ToTable("uw_cell");
                });

            modelBuilder.Entity("Domain.Entities.UwEmployee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ObjectCreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("TypeId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("WarehouseId")
                        .HasColumnType("uuid");

                    b.Property<string>("WortkSchedule")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.HasIndex("UserId");

                    b.HasIndex("WarehouseId");

                    b.ToTable("uw_employee");
                });

            modelBuilder.Entity("Domain.Entities.UwEmployeeType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ObjectCreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("employee_type");
                });

            modelBuilder.Entity("Domain.Entities.UwImage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("ObjectCreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("uw_images");
                });

            modelBuilder.Entity("Domain.Entities.UwImageProductLink", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ImageId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ObjectCreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.HasIndex("ProductId");

                    b.ToTable("uw_product_link");
                });

            modelBuilder.Entity("Domain.Entities.UwProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<long>("Article")
                        .HasColumnType("bigint");

                    b.Property<string>("Color")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("ObjectCreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("uw_product");
                });

            modelBuilder.Entity("Domain.Entities.UwProductStage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ObjectCreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Stage")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("uw_product_stage");
                });

            modelBuilder.Entity("Domain.Entities.UwProductWay", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ObjectCreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<long>("Quantity")
                        .HasColumnType("bigint");

                    b.Property<Guid>("WayBillId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("WayBillId");

                    b.ToTable("uw_product_way");
                });

            modelBuilder.Entity("Domain.Entities.UwReceivedProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ObjectCreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<long>("Quantity")
                        .HasColumnType("bigint");

                    b.Property<Guid>("StageId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("WarehouseId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.HasIndex("ProductId");

                    b.HasIndex("StageId");

                    b.HasIndex("WarehouseId");

                    b.ToTable("uw_received_product");
                });

            modelBuilder.Entity("Domain.Entities.UwReceivedProductAction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ActionTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ObjectCreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("ReceivedProductId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TypeId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ReceivedProductId");

                    b.HasIndex("TypeId");

                    b.ToTable("uw_received_product_action");
                });

            modelBuilder.Entity("Domain.Entities.UwReceivedProductCell", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CellId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ObjectCreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("Quantity")
                        .HasColumnType("bigint");

                    b.Property<Guid>("ReceivedProductId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CellId");

                    b.HasIndex("ReceivedProductId");

                    b.ToTable("uw_received_product_cell");
                });

            modelBuilder.Entity("Domain.Entities.UwUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Login")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime>("ObjectCreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("OtherContacts")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Telephone")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("uw_user");
                });

            modelBuilder.Entity("Domain.Entities.UwWarehouse", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Coordinates")
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("House")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime>("ObjectCreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("uw_warehouse");
                });

            modelBuilder.Entity("Domain.Entities.UwWasteBill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("ActualLeaveAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Barcode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("CarId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Number")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric(20,0)")
                        .HasDefaultValueSql("nextval('\"WasteBillNumbers\"')");

                    b.Property<DateTime>("ObjectCreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<long>("Quantity")
                        .HasColumnType("bigint");

                    b.Property<Guid>("StageId")
                        .HasColumnType("uuid");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<Guid>("WarehouseId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("WillLeaveAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("Number")
                        .IsUnique();

                    b.HasIndex("OwnerId");

                    b.HasIndex("ProductId");

                    b.HasIndex("StageId");

                    b.HasIndex("WarehouseId");

                    b.ToTable("uw_waste_bill");
                });

            modelBuilder.Entity("Domain.Entities.UwWayBill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Barcode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("CarId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateOfArrival")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Note")
                        .HasColumnType("text");

                    b.Property<decimal>("Number")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric(20,0)")
                        .HasDefaultValueSql("nextval('\"WayBillNumbers\"')");

                    b.Property<DateTime>("ObjectCreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uuid");

                    b.Property<long>("Quantity")
                        .HasColumnType("bigint");

                    b.Property<Guid>("StageId")
                        .HasColumnType("uuid");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<Guid>("WarehouseId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("Number")
                        .IsUnique();

                    b.HasIndex("OwnerId");

                    b.HasIndex("StageId");

                    b.HasIndex("WarehouseId");

                    b.ToTable("uw_way_bill");
                });

            modelBuilder.Entity("Domain.Entities.UwWriteOffType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ObjectCreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("uw_write_off_type");
                });

            modelBuilder.Entity("Domain.Entities.UwWrittenOffReceivedProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ObjectCreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("Quantity")
                        .HasColumnType("bigint");

                    b.Property<Guid>("ReceivedProductId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TypeId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ReceivedProductId");

                    b.HasIndex("TypeId");

                    b.ToTable("uw_written_off_received_product");
                });

            modelBuilder.Entity("Domain.Entities.UwBasketReceivedProductLink", b =>
                {
                    b.HasOne("Domain.Entities.UwBasket", "Basket")
                        .WithMany()
                        .HasForeignKey("BasketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.UwReceivedProductCell", "ReceivedProductCell")
                        .WithMany()
                        .HasForeignKey("ReceivedProductCellId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Basket");

                    b.Navigation("ReceivedProductCell");
                });

            modelBuilder.Entity("Domain.Entities.UwCell", b =>
                {
                    b.HasOne("Domain.Entities.UwEmployee", "CreatedByEmployee")
                        .WithMany()
                        .HasForeignKey("CreatedByEmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.UwWarehouse", "Warehouse")
                        .WithMany()
                        .HasForeignKey("WarehouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedByEmployee");

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("Domain.Entities.UwEmployee", b =>
                {
                    b.HasOne("Domain.Entities.UwEmployeeType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.UwUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.UwWarehouse", "Warehouse")
                        .WithMany()
                        .HasForeignKey("WarehouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Type");

                    b.Navigation("User");

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("Domain.Entities.UwImageProductLink", b =>
                {
                    b.HasOne("Domain.Entities.UwImage", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.UwProduct", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Image");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Domain.Entities.UwProductWay", b =>
                {
                    b.HasOne("Domain.Entities.UwProduct", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.UwWayBill", "WayBill")
                        .WithMany("ProductWays")
                        .HasForeignKey("WayBillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("WayBill");
                });

            modelBuilder.Entity("Domain.Entities.UwReceivedProduct", b =>
                {
                    b.HasOne("Domain.Entities.UwUser", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.UwProduct", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.UwProductStage", "Stage")
                        .WithMany()
                        .HasForeignKey("StageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.UwWarehouse", "Warehouse")
                        .WithMany()
                        .HasForeignKey("WarehouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");

                    b.Navigation("Product");

                    b.Navigation("Stage");

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("Domain.Entities.UwReceivedProductAction", b =>
                {
                    b.HasOne("Domain.Entities.UwEmployee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.UwReceivedProduct", "ReceivedProduct")
                        .WithMany()
                        .HasForeignKey("ReceivedProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.UwActionType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("ReceivedProduct");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("Domain.Entities.UwReceivedProductCell", b =>
                {
                    b.HasOne("Domain.Entities.UwCell", "Cell")
                        .WithMany("ProductCells")
                        .HasForeignKey("CellId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.UwReceivedProduct", "ReceivedProduct")
                        .WithMany("Cells")
                        .HasForeignKey("ReceivedProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cell");

                    b.Navigation("ReceivedProduct");
                });

            modelBuilder.Entity("Domain.Entities.UwWasteBill", b =>
                {
                    b.HasOne("Domain.Entities.UwCar", "Car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.UwUser", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.UwProduct", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.UwProductStage", "Stage")
                        .WithMany()
                        .HasForeignKey("StageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.UwWarehouse", "Warehouse")
                        .WithMany()
                        .HasForeignKey("WarehouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Owner");

                    b.Navigation("Product");

                    b.Navigation("Stage");

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("Domain.Entities.UwWayBill", b =>
                {
                    b.HasOne("Domain.Entities.UwCar", "Car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.UwUser", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.UwProductStage", "Stage")
                        .WithMany()
                        .HasForeignKey("StageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.UwWarehouse", "Warehouse")
                        .WithMany()
                        .HasForeignKey("WarehouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Owner");

                    b.Navigation("Stage");

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("Domain.Entities.UwWrittenOffReceivedProduct", b =>
                {
                    b.HasOne("Domain.Entities.UwEmployee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.UwReceivedProduct", "ReceivedProduct")
                        .WithMany()
                        .HasForeignKey("ReceivedProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.UwWriteOffType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("ReceivedProduct");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("Domain.Entities.UwCell", b =>
                {
                    b.Navigation("ProductCells");
                });

            modelBuilder.Entity("Domain.Entities.UwReceivedProduct", b =>
                {
                    b.Navigation("Cells");
                });

            modelBuilder.Entity("Domain.Entities.UwWayBill", b =>
                {
                    b.Navigation("ProductWays");
                });
#pragma warning restore 612, 618
        }
    }
}
