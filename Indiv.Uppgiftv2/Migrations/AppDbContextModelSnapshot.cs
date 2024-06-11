﻿// <auto-generated />
using System;
using Indiv.Uppgiftv2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Indiv.Uppgiftv2.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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
                            Date = new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EndTime = new DateTime(2024, 7, 1, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            StartTime = new DateTime(2024, 7, 1, 9, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            AppointmentID = 1002,
                            CustomerID = 1001,
                            Date = new DateTime(2024, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EndTime = new DateTime(2024, 7, 4, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            StartTime = new DateTime(2024, 7, 4, 9, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            AppointmentID = 1003,
                            CustomerID = 1001,
                            Date = new DateTime(2024, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EndTime = new DateTime(2024, 7, 8, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            StartTime = new DateTime(2024, 7, 8, 9, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            AppointmentID = 1004,
                            CustomerID = 1002,
                            Date = new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EndTime = new DateTime(2024, 7, 1, 11, 0, 0, 0, DateTimeKind.Unspecified),
                            StartTime = new DateTime(2024, 7, 1, 10, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            AppointmentID = 1005,
                            CustomerID = 1002,
                            Date = new DateTime(2024, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EndTime = new DateTime(2024, 7, 2, 14, 0, 0, 0, DateTimeKind.Unspecified),
                            StartTime = new DateTime(2024, 7, 2, 13, 0, 0, 0, DateTimeKind.Unspecified)
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

                    b.HasKey("CustomerID");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerID = 1001,
                            FirstName = "Andrea",
                            LastName = "Almer",
                            PassWord = "abC321"
                        },
                        new
                        {
                            CustomerID = 1002,
                            FirstName = "Beata",
                            LastName = "Almer",
                            PassWord = "123Fyra"
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

                    b.HasKey("EmployeeID");

                    b.ToTable("Employees");
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

            modelBuilder.Entity("IndUppClassModels.Customer", b =>
                {
                    b.Navigation("Appointments");
                });
#pragma warning restore 612, 618
        }
    }
}
