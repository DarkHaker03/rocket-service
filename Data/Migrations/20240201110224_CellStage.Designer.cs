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
    [Migration("20240201110224_CellStage")]
    partial class CellStage
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.HasSequence("BillNumbers");

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

            modelBuilder.Entity("Domain.Entities.UwBill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("ActualRealizationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("CarId")
                        .HasColumnType("uuid");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Number")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric(20,0)")
                        .HasDefaultValueSql("nextval('\"BillNumbers\"')");

                    b.Property<DateTime>("ObjectCreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uuid");

                    b.Property<long>("Quantity")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("RealizationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<Guid>("WarehouseId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("Number")
                        .IsUnique();

                    b.HasIndex("OwnerId");

                    b.HasIndex("WarehouseId");

                    b.ToTable("uw_bill");
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

                    b.Property<Guid>("StageId")
                        .HasColumnType("uuid");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<Guid>("WarehouseId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CreatedByEmployeeId");

                    b.HasIndex("StageId");

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

                    b.HasIndex("UserId")
                        .IsUnique();

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

                    b.ToTable("uw_image_product_link");
                });

            modelBuilder.Entity("Domain.Entities.UwProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Article")
                        .IsRequired()
                        .HasColumnType("text");

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

            modelBuilder.Entity("Domain.Entities.UwProductBill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BillId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ObjectCreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<long>("Quantity")
                        .HasColumnType("bigint");

                    b.Property<Guid>("WasteBillId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("BillId");

                    b.HasIndex("ProductId");

                    b.ToTable("uw_product_bill");
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

                    b.Property<Guid?>("ImageId")
                        .HasColumnType("uuid");

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

                    b.HasIndex("ImageId");

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
                        .WithMany("ProductLinks")
                        .HasForeignKey("BasketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.UwReceivedProductCell", "ReceivedProductCell")
                        .WithMany("BasketReceivedProductLinks")
                        .HasForeignKey("ReceivedProductCellId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Basket");

                    b.Navigation("ReceivedProductCell");
                });

            modelBuilder.Entity("Domain.Entities.UwBill", b =>
                {
                    b.HasOne("Domain.Entities.UwCar", "Car")
                        .WithMany("Bills")
                        .HasForeignKey("CarId");

                    b.HasOne("Domain.Entities.UwUser", "Owner")
                        .WithMany("Bills")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.UwWarehouse", "Warehouse")
                        .WithMany("WasteBills")
                        .HasForeignKey("WarehouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Owner");

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("Domain.Entities.UwCell", b =>
                {
                    b.HasOne("Domain.Entities.UwEmployee", "CreatedByEmployee")
                        .WithMany()
                        .HasForeignKey("CreatedByEmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.UwProductStage", "Stage")
                        .WithMany("Cells")
                        .HasForeignKey("StageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.UwWarehouse", "Warehouse")
                        .WithMany("Cells")
                        .HasForeignKey("WarehouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedByEmployee");

                    b.Navigation("Stage");

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("Domain.Entities.UwEmployee", b =>
                {
                    b.HasOne("Domain.Entities.UwEmployeeType", "Type")
                        .WithMany("Employees")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.UwUser", "User")
                        .WithOne("Employee")
                        .HasForeignKey("Domain.Entities.UwEmployee", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.UwWarehouse", "Warehouse")
                        .WithMany("Employees")
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
                        .WithMany("ImageProductLinks")
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.UwProduct", "Product")
                        .WithMany("ImageLinks")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Image");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Domain.Entities.UwProductBill", b =>
                {
                    b.HasOne("Domain.Entities.UwBill", "Bill")
                        .WithMany("ProductsBills")
                        .HasForeignKey("BillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.UwProduct", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bill");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Domain.Entities.UwReceivedProduct", b =>
                {
                    b.HasOne("Domain.Entities.UwUser", "Owner")
                        .WithMany("ReceivedProducts")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.UwProduct", "Product")
                        .WithMany("ReceivedProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.UwWarehouse", "Warehouse")
                        .WithMany("ReceivedProducts")
                        .HasForeignKey("WarehouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");

                    b.Navigation("Product");

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("Domain.Entities.UwReceivedProductAction", b =>
                {
                    b.HasOne("Domain.Entities.UwEmployee", "Employee")
                        .WithMany("ProductActions")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.UwReceivedProduct", "ReceivedProduct")
                        .WithMany()
                        .HasForeignKey("ReceivedProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.UwActionType", "Type")
                        .WithMany("ProductActions")
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

            modelBuilder.Entity("Domain.Entities.UwUser", b =>
                {
                    b.HasOne("Domain.Entities.UwImage", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId");

                    b.Navigation("Image");
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
                        .WithMany("WrittenOffReceivedProducts")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("ReceivedProduct");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("Domain.Entities.UwActionType", b =>
                {
                    b.Navigation("ProductActions");
                });

            modelBuilder.Entity("Domain.Entities.UwBasket", b =>
                {
                    b.Navigation("ProductLinks");
                });

            modelBuilder.Entity("Domain.Entities.UwBill", b =>
                {
                    b.Navigation("ProductsBills");
                });

            modelBuilder.Entity("Domain.Entities.UwCar", b =>
                {
                    b.Navigation("Bills");
                });

            modelBuilder.Entity("Domain.Entities.UwCell", b =>
                {
                    b.Navigation("ProductCells");
                });

            modelBuilder.Entity("Domain.Entities.UwEmployee", b =>
                {
                    b.Navigation("ProductActions");
                });

            modelBuilder.Entity("Domain.Entities.UwEmployeeType", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Domain.Entities.UwImage", b =>
                {
                    b.Navigation("ImageProductLinks");
                });

            modelBuilder.Entity("Domain.Entities.UwProduct", b =>
                {
                    b.Navigation("ImageLinks");

                    b.Navigation("ReceivedProducts");
                });

            modelBuilder.Entity("Domain.Entities.UwProductStage", b =>
                {
                    b.Navigation("Cells");
                });

            modelBuilder.Entity("Domain.Entities.UwReceivedProduct", b =>
                {
                    b.Navigation("Cells");
                });

            modelBuilder.Entity("Domain.Entities.UwReceivedProductCell", b =>
                {
                    b.Navigation("BasketReceivedProductLinks");
                });

            modelBuilder.Entity("Domain.Entities.UwUser", b =>
                {
                    b.Navigation("Bills");

                    b.Navigation("Employee");

                    b.Navigation("ReceivedProducts");
                });

            modelBuilder.Entity("Domain.Entities.UwWarehouse", b =>
                {
                    b.Navigation("Cells");

                    b.Navigation("Employees");

                    b.Navigation("ReceivedProducts");

                    b.Navigation("WasteBills");
                });

            modelBuilder.Entity("Domain.Entities.UwWriteOffType", b =>
                {
                    b.Navigation("WrittenOffReceivedProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
