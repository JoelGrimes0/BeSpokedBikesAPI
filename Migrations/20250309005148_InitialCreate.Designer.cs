﻿// <auto-generated />
using System;
using BeSpokedBikesAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BeSpokedBikesAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250309005148_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BeSpokedBikesAPI.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "789 Pine St",
                            FirstName = "Michael",
                            LastName = "Johnson",
                            Phone = "555-9876",
                            StartDate = new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Address = "321 Cedar St",
                            FirstName = "Emily",
                            LastName = "Williams",
                            Phone = "555-6543",
                            StartDate = new DateTime(2021, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("BeSpokedBikesAPI.Models.Discount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BeginDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("DiscountPercentage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Discounts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BeginDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DiscountPercentage = 10m,
                            EndDate = new DateTime(2023, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductId = 1
                        });
                });

            modelBuilder.Entity("BeSpokedBikesAPI.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("CommissionPercentage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Manufacturer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("PurchasePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("QtyOnHand")
                        .HasColumnType("int");

                    b.Property<decimal>("SalePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Style")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CommissionPercentage = 10m,
                            Manufacturer = "Trek",
                            Name = "Road Bike",
                            PurchasePrice = 500m,
                            QtyOnHand = 10,
                            SalePrice = 1000m,
                            Style = "Racing"
                        },
                        new
                        {
                            Id = 2,
                            CommissionPercentage = 12m,
                            Manufacturer = "Giant",
                            Name = "Mountain Bike",
                            PurchasePrice = 800m,
                            QtyOnHand = 5,
                            SalePrice = 1500m,
                            Style = "Off-Road"
                        },
                        new
                        {
                            Id = 3,
                            CommissionPercentage = 8m,
                            Manufacturer = "Specialized",
                            Name = "Hybrid Bike",
                            PurchasePrice = 300m,
                            QtyOnHand = 15,
                            SalePrice = 700m,
                            Style = "Casual"
                        });
                });

            modelBuilder.Entity("BeSpokedBikesAPI.Models.Sale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<decimal>("SalePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("SalesDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("SalespersonCommission")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SalespersonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductId");

                    b.HasIndex("SalespersonId");

                    b.ToTable("Sales");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerId = 1,
                            ProductId = 1,
                            SalePrice = 1000m,
                            SalesDate = new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SalespersonCommission = 0m,
                            SalespersonId = 1
                        },
                        new
                        {
                            Id = 2,
                            CustomerId = 2,
                            ProductId = 2,
                            SalePrice = 1500m,
                            SalesDate = new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SalespersonCommission = 0m,
                            SalespersonId = 2
                        });
                });

            modelBuilder.Entity("BeSpokedBikesAPI.Models.Salesperson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Manager")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("TerminationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("FirstName", "LastName", "Phone")
                        .IsUnique()
                        .HasFilter("[FirstName] IS NOT NULL AND [LastName] IS NOT NULL AND [Phone] IS NOT NULL");

                    b.ToTable("Salespersons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "123 Main St",
                            FirstName = "John",
                            LastName = "Doe",
                            Manager = "Alice",
                            Phone = "555-1234",
                            StartDate = new DateTime(2020, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Address = "456 Oak St",
                            FirstName = "Jane",
                            LastName = "Smith",
                            Manager = "Bob",
                            Phone = "555-5678",
                            StartDate = new DateTime(2021, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("BeSpokedBikesAPI.Models.Sale", b =>
                {
                    b.HasOne("BeSpokedBikesAPI.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeSpokedBikesAPI.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeSpokedBikesAPI.Models.Salesperson", "Salesperson")
                        .WithMany()
                        .HasForeignKey("SalespersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Product");

                    b.Navigation("Salesperson");
                });
#pragma warning restore 612, 618
        }
    }
}
