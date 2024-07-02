﻿// <auto-generated />
using System;
using Indiv.Uppgiftv2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Indiv.Uppgiftv2.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240630162801_appDTO")]
    partial class appDTO
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("IndProjModels.AppointmentChanges", b =>
                {
                    b.Property<int>("AppointmentChangeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AppointmentChangeID"));

                    b.Property<int>("AppointmentID")
                        .HasColumnType("int");

                    b.Property<string>("ChangeType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Field")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NewValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PreviousValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("AppointmentChangeID");

                    b.HasIndex("AppointmentID");

                    b.ToTable("AppointmentChanges");
                });

            modelBuilder.Entity("IndUppClassModels.Appointment", b =>
                {
                    b.Property<int>("AppointmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AppointmentID"));

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("AppointmentID");

                    b.HasIndex("CustomerID");

                    b.ToTable("Appointments");

                    b.HasData(
                        new
                        {
                            AppointmentID = 1001,
                            CustomerID = 1001,
                            Date = new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EndTime = new DateTime(2024, 6, 1, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            StartTime = new DateTime(2024, 6, 1, 9, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            AppointmentID = 1002,
                            CustomerID = 1001,
                            Date = new DateTime(2024, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EndTime = new DateTime(2024, 6, 4, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            StartTime = new DateTime(2024, 6, 4, 9, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            AppointmentID = 1003,
                            CustomerID = 1001,
                            Date = new DateTime(2024, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EndTime = new DateTime(2024, 6, 8, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            StartTime = new DateTime(2024, 6, 8, 9, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            AppointmentID = 1004,
                            CustomerID = 1002,
                            Date = new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EndTime = new DateTime(2024, 6, 1, 11, 0, 0, 0, DateTimeKind.Unspecified),
                            StartTime = new DateTime(2024, 6, 1, 10, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            AppointmentID = 1005,
                            CustomerID = 1002,
                            Date = new DateTime(2024, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EndTime = new DateTime(2024, 6, 2, 14, 0, 0, 0, DateTimeKind.Unspecified),
                            StartTime = new DateTime(2024, 6, 2, 13, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("IndUppClassModels.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerID"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("PassWord")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("CustomerID");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerID = 1001,
                            FirstName = "Andrea",
                            LastName = "Almer",
                            PassWord = "abC321",
                            Username = "AA1001"
                        },
                        new
                        {
                            CustomerID = 1002,
                            FirstName = "Beata",
                            LastName = "Almer",
                            PassWord = "123Fyra",
                            Username = "BA1002"
                        });
                });

            modelBuilder.Entity("IndUppClassModels.Employee", b =>
                {
                    b.Property<int>("EmployeeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeID"));

                    b.Property<string>("EFirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ELastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EPassWord")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeID");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeID = 1001,
                            EFirstName = "Admin",
                            ELastName = "AdminLastName",
                            EPassWord = "123Password",
                            UserName = "Admin1001"
                        });
                });

            modelBuilder.Entity("IndProjModels.AppointmentChanges", b =>
                {
                    b.HasOne("IndUppClassModels.Appointment", "Appointment")
                        .WithMany("Changes")
                        .HasForeignKey("AppointmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Appointment");
                });

            modelBuilder.Entity("IndUppClassModels.Appointment", b =>
                {
                    b.HasOne("IndUppClassModels.Customer", "Customer")
                        .WithMany("Appointments")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("IndUppClassModels.Appointment", b =>
                {
                    b.Navigation("Changes");
                });

            modelBuilder.Entity("IndUppClassModels.Customer", b =>
                {
                    b.Navigation("Appointments");
                });
#pragma warning restore 612, 618
        }
    }
}
