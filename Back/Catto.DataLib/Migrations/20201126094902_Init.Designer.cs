﻿// <auto-generated />
using System;
using Catto.DataLib.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Catto.DataLib.Migrations
{
    [DbContext(typeof(AtomContextDB))]
    [Migration("20201126094902_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Catto.DataLib.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Catto.DataLib.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FamilyName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Phone")
                        .HasColumnType("int");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Catto.DataLib.Models.Machine", b =>
                {
                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessLevel")
                        .HasColumnType("int");

                    b.Property<string>("MalfunctionType")
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<string>("ManualLink")
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<string>("Speciality")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Model");

                    b.ToTable("Machines");
                });

            modelBuilder.Entity("Catto.DataLib.Models.Property", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("MachineModel")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("ManagerId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("MachineModel");

                    b.HasIndex("ManagerId");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("Catto.DataLib.Models.RepairOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ComplitionTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreationTime")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatorId")
                        .HasColumnType("int");

                    b.Property<string>("MalfunctionDesc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MalfunctionType")
                        .IsRequired()
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<DateTime>("PlannedTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<int>("PropertyId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("PropertyId");

                    b.ToTable("RepairOrders");
                });

            modelBuilder.Entity("ManagerRepairOrder", b =>
                {
                    b.Property<int>("ManagersId")
                        .HasColumnType("int");

                    b.Property<int>("RepairOrdersId")
                        .HasColumnType("int");

                    b.HasKey("ManagersId", "RepairOrdersId");

                    b.HasIndex("RepairOrdersId");

                    b.ToTable("ManagerRepairOrder");
                });

            modelBuilder.Entity("RepairOrderTechnician", b =>
                {
                    b.Property<int>("RepairOrdersId")
                        .HasColumnType("int");

                    b.Property<int>("TechniciansId")
                        .HasColumnType("int");

                    b.HasKey("RepairOrdersId", "TechniciansId");

                    b.HasIndex("TechniciansId");

                    b.ToTable("RepairOrderTechnician");
                });

            modelBuilder.Entity("Catto.DataLib.Models.Manager", b =>
                {
                    b.HasBaseType("Catto.DataLib.Models.Employee");

                    b.Property<string>("Rank")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.ToTable("Managers");
                });

            modelBuilder.Entity("Catto.DataLib.Models.Technician", b =>
                {
                    b.HasBaseType("Catto.DataLib.Models.Employee");

                    b.Property<int>("AccessLevel")
                        .HasColumnType("int");

                    b.Property<int?>("ManagerId")
                        .HasColumnType("int");

                    b.Property<string>("Speciality")
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("ManagerId");

                    b.ToTable("Technician");
                });

            modelBuilder.Entity("Catto.DataLib.Models.Employee", b =>
                {
                    b.HasOne("Catto.DataLib.Models.Account", "Account")
                        .WithOne("Employee")
                        .HasForeignKey("Catto.DataLib.Models.Employee", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("Catto.DataLib.Models.Property", b =>
                {
                    b.HasOne("Catto.DataLib.Models.Machine", "Machine")
                        .WithMany("PropList")
                        .HasForeignKey("MachineModel")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Catto.DataLib.Models.Manager", "Manager")
                        .WithMany("Properties")
                        .HasForeignKey("ManagerId");

                    b.Navigation("Machine");

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("Catto.DataLib.Models.RepairOrder", b =>
                {
                    b.HasOne("Catto.DataLib.Models.Employee", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId");

                    b.HasOne("Catto.DataLib.Models.Property", "Property")
                        .WithMany("RepairOrders")
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");

                    b.Navigation("Property");
                });

            modelBuilder.Entity("ManagerRepairOrder", b =>
                {
                    b.HasOne("Catto.DataLib.Models.Manager", null)
                        .WithMany()
                        .HasForeignKey("ManagersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Catto.DataLib.Models.RepairOrder", null)
                        .WithMany()
                        .HasForeignKey("RepairOrdersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RepairOrderTechnician", b =>
                {
                    b.HasOne("Catto.DataLib.Models.RepairOrder", null)
                        .WithMany()
                        .HasForeignKey("RepairOrdersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Catto.DataLib.Models.Technician", null)
                        .WithMany()
                        .HasForeignKey("TechniciansId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Catto.DataLib.Models.Manager", b =>
                {
                    b.HasOne("Catto.DataLib.Models.Employee", null)
                        .WithOne()
                        .HasForeignKey("Catto.DataLib.Models.Manager", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Catto.DataLib.Models.Technician", b =>
                {
                    b.HasOne("Catto.DataLib.Models.Employee", null)
                        .WithOne()
                        .HasForeignKey("Catto.DataLib.Models.Technician", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("Catto.DataLib.Models.Manager", "Manager")
                        .WithMany("Technicians")
                        .HasForeignKey("ManagerId");

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("Catto.DataLib.Models.Account", b =>
                {
                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Catto.DataLib.Models.Machine", b =>
                {
                    b.Navigation("PropList");
                });

            modelBuilder.Entity("Catto.DataLib.Models.Property", b =>
                {
                    b.Navigation("RepairOrders");
                });

            modelBuilder.Entity("Catto.DataLib.Models.Manager", b =>
                {
                    b.Navigation("Properties");

                    b.Navigation("Technicians");
                });
#pragma warning restore 612, 618
        }
    }
}