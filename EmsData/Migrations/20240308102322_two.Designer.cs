﻿// <auto-generated />
using System;
using EmsData.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmsData.Migrations
{
    [DbContext(typeof(EmsDbContext))]
    [Migration("20240308102322_two")]
    partial class two
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EmsEntity.Department", b =>
                {
                    b.Property<int>("Dept_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Dept_ID"), 1L, 1);

                    b.Property<string>("Dept_Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Dept_ID");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("EmsEntity.Employee", b =>
                {
                    b.Property<string>("Emp_ID")
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<int>("Emp_Basic")
                        .HasColumnType("int");

                    b.Property<string>("Emp_Contact_Num")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<DateTime>("Emp_Date_of_Birth")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Emp_Date_of_Joining")
                        .HasColumnType("datetime2");

                    b.Property<int>("Emp_Dept_ID")
                        .HasColumnType("int");

                    b.Property<string>("Emp_Designation")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Emp_First_Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Emp_Gender")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("Emp_Grade")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("Emp_Home_Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Emp_Last_Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Emp_Marital_Status")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.HasKey("Emp_ID");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("EmsEntity.Grade_Master", b =>
                {
                    b.Property<string>("Grade_Code")
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("Max_Salary")
                        .HasColumnType("int");

                    b.Property<int>("Min_Salary")
                        .HasColumnType("int");

                    b.HasKey("Grade_Code");

                    b.ToTable("Grade_Masters");
                });

            modelBuilder.Entity("EmsEntity.User_Master", b =>
                {
                    b.Property<string>("UserID")
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserPassword")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.HasKey("UserID");

                    b.ToTable("User_Masters");
                });
#pragma warning restore 612, 618
        }
    }
}
