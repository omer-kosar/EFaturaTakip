﻿// <auto-generated />
using System;
using EFaturaTakip.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFaturaTakip.Entities.Migrations
{
    [DbContext(typeof(EFaturaTakipContext))]
    [Migration("20220820184842_AddUserCompanyId")]
    partial class AddUserCompanyId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EFaturaTakip.Entities.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ApartmentNumber")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("CentralRegistrationNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CommercialRegistrationNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("CompanySaveType")
                        .HasColumnType("int");

                    b.Property<string>("Country")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("District")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("EMailAdress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FaxNumber")
                        .HasMaxLength(17)
                        .HasColumnType("nvarchar(17)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("FlatNumber")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("LastName")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("MobilePhone")
                        .IsRequired()
                        .HasMaxLength(17)
                        .HasColumnType("nvarchar(17)");

                    b.Property<string>("Province")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("ServicePassword")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ServiceUserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TaxOffice")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TcKimlikNo")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Title")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("VergiNo")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Company", (string)null);
                });

            modelBuilder.Entity("EFaturaTakip.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Role", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("a82e3d9f-48e5-4766-a406-36f1dcaeae4f"),
                            Name = "Admin"
                        },
                        new
                        {
                            Id = new Guid("14b47dd5-73f4-4c09-a98e-d1732fdd529d"),
                            Name = "TaxPayer"
                        },
                        new
                        {
                            Id = new Guid("a513bf44-7e12-4a2e-b62b-6776197a4ea1"),
                            Name = "Accountant"
                        });
                });

            modelBuilder.Entity("EFaturaTakip.Entities.Stock", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<int>("Unit")
                        .HasColumnType("int");

                    b.Property<int>("ValueAddedTax")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Stock");
                });

            modelBuilder.Entity("EFaturaTakip.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("LastLoginDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(17)
                        .HasColumnType("nvarchar(17)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("EFaturaTakip.Entities.UserRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRole", (string)null);
                });

            modelBuilder.Entity("EFaturaTakip.Entities.User", b =>
                {
                    b.HasOne("EFaturaTakip.Entities.Company", "Company")
                        .WithMany("Users")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("EFaturaTakip.Entities.UserRole", b =>
                {
                    b.HasOne("EFaturaTakip.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFaturaTakip.Entities.User", "User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EFaturaTakip.Entities.Company", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("EFaturaTakip.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("EFaturaTakip.Entities.User", b =>
                {
                    b.Navigation("Roles");
                });
#pragma warning restore 612, 618
        }
    }
}
