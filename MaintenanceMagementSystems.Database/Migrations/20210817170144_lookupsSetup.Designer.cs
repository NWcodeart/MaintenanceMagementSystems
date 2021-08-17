﻿// <auto-generated />
using System;
using MaintenanceManagementSystem.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MaintenanceManagementSystem.Database.Migrations
{
    [DbContext(typeof(MaintenanceSysContext))]
    [Migration("20210817170144_lookupsSetup")]
    partial class lookupsSetup
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MaintenanceManagementSystem.Database.Lookup.CancellationReason", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ReasonTypeAr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReasonTypeEn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CancelationReasons");
                });

            modelBuilder.Entity("MaintenanceManagementSystem.Database.Lookup.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CityNameAr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CityNameEn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("MaintenanceManagementSystem.Database.Lookup.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CountryNameAr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryNameEn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("MaintenanceManagementSystem.Database.Lookup.MaintenanceType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MaintenanceTypeNameAr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaintenanceTypeNameEn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MaintenanceTypes");
                });

            modelBuilder.Entity("MaintenanceManagementSystem.Database.Lookup.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StatusTypeAr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StatusTypeEn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("MaintenanceManagementSystem.Database.Lookup.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoleNameAr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleNameEn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("MaintenanceManagementSystem.Database.ManyToMany.BackOfficesTickets", b =>
                {
                    b.Property<int>("BackOfficeId")
                        .HasColumnType("int");

                    b.Property<int>("TicketId")
                        .HasColumnType("int");

                    b.HasKey("BackOfficeId", "TicketId");

                    b.HasIndex("TicketId");

                    b.ToTable("BackOfficesTickets");
                });

            modelBuilder.Entity("MaintenanceManagementSystem.Database.Models.Building", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BuildingManagerId")
                        .HasColumnType("int");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<bool>("IsOwned")
                        .HasColumnType("bit");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BuildingManagerId");

                    b.HasIndex("CityId");

                    b.ToTable("Buildings");
                });

            modelBuilder.Entity("MaintenanceManagementSystem.Database.Models.Floor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BuildingId")
                        .HasColumnType("int");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.HasKey("Id");

                    b.HasIndex("BuildingId");

                    b.ToTable("Floors");
                });

            modelBuilder.Entity("MaintenanceManagementSystem.Database.Models.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ApprovalState")
                        .HasColumnType("int");

                    b.Property<int>("BeneficiaryID")
                        .HasColumnType("int");

                    b.Property<string>("BuildingManagerComment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CancellationReasonID")
                        .HasColumnType("int");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FloorId")
                        .HasColumnType("int");

                    b.Property<bool>("IsCancelled")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("MaintenanceTypeID")
                        .HasColumnType("int");

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RejectedBy")
                        .HasColumnType("int");

                    b.Property<string>("RejectionReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusID")
                        .HasColumnType("int");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BeneficiaryID");

                    b.HasIndex("CancellationReasonID");

                    b.HasIndex("FloorId");

                    b.HasIndex("MaintenanceTypeID");

                    b.HasIndex("RejectedBy");

                    b.HasIndex("StatusID");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("MaintenanceManagementSystem.Database.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FloorId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsFirstLogin")
                        .HasColumnType("bit");

                    b.Property<bool>("IsForgetPassword")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRememberMe")
                        .HasColumnType("bit");

                    b.Property<int?>("MaintenanceTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserRoleId")
                        .HasColumnType("int");

                    b.Property<int?>("buildingId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FloorId");

                    b.HasIndex("MaintenanceTypeId");

                    b.HasIndex("UserRoleId");

                    b.HasIndex("buildingId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MaintenanceManagementSystem.Database.Lookup.City", b =>
                {
                    b.HasOne("MaintenanceManagementSystem.Database.Lookup.Country", "country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("country");
                });

            modelBuilder.Entity("MaintenanceManagementSystem.Database.ManyToMany.BackOfficesTickets", b =>
                {
                    b.HasOne("MaintenanceManagementSystem.Database.Models.User", "user")
                        .WithMany("BackOfficeTickets")
                        .HasForeignKey("BackOfficeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MaintenanceManagementSystem.Database.Models.Ticket", "ticket")
                        .WithMany("backOfficesTickets")
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ticket");

                    b.Navigation("user");
                });

            modelBuilder.Entity("MaintenanceManagementSystem.Database.Models.Building", b =>
                {
                    b.HasOne("MaintenanceManagementSystem.Database.Models.User", "UserbuildingManager")
                        .WithMany()
                        .HasForeignKey("BuildingManagerId");

                    b.HasOne("MaintenanceManagementSystem.Database.Lookup.City", "city")
                        .WithMany("buildings")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("city");

                    b.Navigation("UserbuildingManager");
                });

            modelBuilder.Entity("MaintenanceManagementSystem.Database.Models.Floor", b =>
                {
                    b.HasOne("MaintenanceManagementSystem.Database.Models.Building", "building")
                        .WithMany("floors")
                        .HasForeignKey("BuildingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("building");
                });

            modelBuilder.Entity("MaintenanceManagementSystem.Database.Models.Ticket", b =>
                {
                    b.HasOne("MaintenanceManagementSystem.Database.Models.User", "BeneficiaryUser")
                        .WithMany("BeneficiaryTickets")
                        .HasForeignKey("BeneficiaryID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MaintenanceManagementSystem.Database.Lookup.CancellationReason", "cancelationReason")
                        .WithMany("tickets")
                        .HasForeignKey("CancellationReasonID");

                    b.HasOne("MaintenanceManagementSystem.Database.Models.Floor", "floor")
                        .WithMany("tickets")
                        .HasForeignKey("FloorId");

                    b.HasOne("MaintenanceManagementSystem.Database.Lookup.MaintenanceType", "maintenanceType")
                        .WithMany("tickets")
                        .HasForeignKey("MaintenanceTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MaintenanceManagementSystem.Database.Models.User", "UserRejected")
                        .WithMany("TicketsRejected")
                        .HasForeignKey("RejectedBy");

                    b.HasOne("MaintenanceManagementSystem.Database.Lookup.Status", "status")
                        .WithMany("ticket")
                        .HasForeignKey("StatusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BeneficiaryUser");

                    b.Navigation("cancelationReason");

                    b.Navigation("floor");

                    b.Navigation("maintenanceType");

                    b.Navigation("status");

                    b.Navigation("UserRejected");
                });

            modelBuilder.Entity("MaintenanceManagementSystem.Database.Models.User", b =>
                {
                    b.HasOne("MaintenanceManagementSystem.Database.Models.Floor", "floor")
                        .WithMany("users")
                        .HasForeignKey("FloorId");

                    b.HasOne("MaintenanceManagementSystem.Database.Lookup.MaintenanceType", "maintenanceType")
                        .WithMany("users")
                        .HasForeignKey("MaintenanceTypeId");

                    b.HasOne("MaintenanceManagementSystem.Database.Lookup.UserRole", "userRole")
                        .WithMany("users")
                        .HasForeignKey("UserRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MaintenanceManagementSystem.Database.Models.Building", "building")
                        .WithMany()
                        .HasForeignKey("buildingId");

                    b.Navigation("building");

                    b.Navigation("floor");

                    b.Navigation("maintenanceType");

                    b.Navigation("userRole");
                });

            modelBuilder.Entity("MaintenanceManagementSystem.Database.Lookup.CancellationReason", b =>
                {
                    b.Navigation("tickets");
                });

            modelBuilder.Entity("MaintenanceManagementSystem.Database.Lookup.City", b =>
                {
                    b.Navigation("buildings");
                });

            modelBuilder.Entity("MaintenanceManagementSystem.Database.Lookup.Country", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("MaintenanceManagementSystem.Database.Lookup.MaintenanceType", b =>
                {
                    b.Navigation("tickets");

                    b.Navigation("users");
                });

            modelBuilder.Entity("MaintenanceManagementSystem.Database.Lookup.Status", b =>
                {
                    b.Navigation("ticket");
                });

            modelBuilder.Entity("MaintenanceManagementSystem.Database.Lookup.UserRole", b =>
                {
                    b.Navigation("users");
                });

            modelBuilder.Entity("MaintenanceManagementSystem.Database.Models.Building", b =>
                {
                    b.Navigation("floors");
                });

            modelBuilder.Entity("MaintenanceManagementSystem.Database.Models.Floor", b =>
                {
                    b.Navigation("tickets");

                    b.Navigation("users");
                });

            modelBuilder.Entity("MaintenanceManagementSystem.Database.Models.Ticket", b =>
                {
                    b.Navigation("backOfficesTickets");
                });

            modelBuilder.Entity("MaintenanceManagementSystem.Database.Models.User", b =>
                {
                    b.Navigation("BackOfficeTickets");

                    b.Navigation("BeneficiaryTickets");

                    b.Navigation("TicketsRejected");
                });
#pragma warning restore 612, 618
        }
    }
}
