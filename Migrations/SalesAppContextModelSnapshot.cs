﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SalesApp.Models;

namespace SalesApp.Migrations
{
    [DbContext(typeof(SalesAppContext))]
    partial class SalesAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SalesApp.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DOB")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("HireDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ManagerId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeId = 1,
                            DOB = new DateTime(1979, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Katie",
                            HireDate = new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "Travis",
                            ManagerId = 0
                        },
                        new
                        {
                            EmployeeId = 2,
                            DOB = new DateTime(1982, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Stan",
                            HireDate = new DateTime(1996, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "Smith",
                            ManagerId = 1
                        },
                        new
                        {
                            EmployeeId = 3,
                            DOB = new DateTime(2000, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Sue",
                            HireDate = new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "Chen",
                            ManagerId = 2
                        });
                });

            modelBuilder.Entity("SalesApp.Models.Sales", b =>
                {
                    b.Property<int>("SalesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double?>("Amount")
                        .IsRequired()
                        .HasColumnType("float");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int?>("Quarter")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("Year")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("SalesId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("SalesDb");

                    b.HasData(
                        new
                        {
                            SalesId = 1,
                            Amount = 375987.0,
                            EmployeeId = 2,
                            Quarter = 1,
                            Year = 2020
                        },
                        new
                        {
                            SalesId = 2,
                            Amount = 420357.0,
                            EmployeeId = 2,
                            Quarter = 2,
                            Year = 2020
                        },
                        new
                        {
                            SalesId = 3,
                            Amount = 741258.0,
                            EmployeeId = 3,
                            Quarter = 3,
                            Year = 2020
                        },
                        new
                        {
                            SalesId = 4,
                            Amount = 529183.0,
                            EmployeeId = 3,
                            Quarter = 4,
                            Year = 2020
                        });
                });

            modelBuilder.Entity("SalesApp.Models.Sales", b =>
                {
                    b.HasOne("SalesApp.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });
#pragma warning restore 612, 618
        }
    }
}
