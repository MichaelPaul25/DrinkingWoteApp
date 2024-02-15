﻿// <auto-generated />
using System;
using DrinkingWoteApp_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DrinkingWoteAppAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DrinkingWoteApp_API.Models.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AddressId"));

                    b.Property<string>("Block")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Kecamatan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Kelurahan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PerumahanId")
                        .HasColumnType("int");

                    b.Property<string>("RT_RW")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AddressId");

                    b.HasIndex("PerumahanId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("DrinkingWoteApp_API.Models.Bill", b =>
                {
                    b.Property<int>("BillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BillId"));

                    b.Property<int?>("ConsumentId")
                        .HasColumnType("int");

                    b.Property<int?>("Order_Id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PaymentMethod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentStatusBill")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Qty")
                        .HasColumnType("int");

                    b.Property<float?>("TotalPaid")
                        .HasColumnType("real");

                    b.HasKey("BillId");

                    b.HasIndex("ConsumentId");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("DrinkingWoteApp_API.Models.Consument", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<float?>("Balance")
                        .HasColumnType("real");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("JoinDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("Consuments");
                });

            modelBuilder.Entity("DrinkingWoteApp_API.Models.CrewMember", b =>
                {
                    b.Property<int>("CrewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CrewId"));

                    b.Property<string>("CrewStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CrewId");

                    b.ToTable("Crewers");
                });

            modelBuilder.Entity("DrinkingWoteApp_API.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<int?>("BillId")
                        .HasColumnType("int");

                    b.Property<int?>("ConsumentId")
                        .HasColumnType("int");

                    b.Property<int?>("CrewId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("OrderDone")
                        .HasColumnType("datetime2");

                    b.Property<string>("PaymentMethod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Qty")
                        .HasColumnType("int");

                    b.Property<int?>("ReviewId")
                        .HasColumnType("int");

                    b.Property<string>("StatusOrder")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("TimeOrder")
                        .HasColumnType("datetime2");

                    b.HasKey("OrderId");

                    b.HasIndex("BillId");

                    b.HasIndex("ConsumentId");

                    b.HasIndex("CrewId");

                    b.HasIndex("ReviewId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("DrinkingWoteApp_API.Models.Perumahan", b =>
                {
                    b.Property<int>("PerumahanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PerumahanId"));

                    b.Property<string>("Perumahan_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PerumahanId");

                    b.ToTable("Perumahans");
                });

            modelBuilder.Entity("DrinkingWoteApp_API.Models.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReviewId"));

                    b.Property<int?>("ConsumentId")
                        .HasColumnType("int");

                    b.Property<int?>("CrewId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Order_Id")
                        .HasColumnType("int");

                    b.Property<int?>("RatingStar")
                        .HasColumnType("int");

                    b.HasKey("ReviewId");

                    b.HasIndex("ConsumentId");

                    b.HasIndex("CrewId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("DrinkingWoteApp_API.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("BirthTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ConsumentId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobilePhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DrinkingWoteApp_API.Models.Address", b =>
                {
                    b.HasOne("DrinkingWoteApp_API.Models.Perumahan", "Perumahan")
                        .WithMany()
                        .HasForeignKey("PerumahanId");

                    b.Navigation("Perumahan");
                });

            modelBuilder.Entity("DrinkingWoteApp_API.Models.Bill", b =>
                {
                    b.HasOne("DrinkingWoteApp_API.Models.Consument", "Consument")
                        .WithMany("Bills")
                        .HasForeignKey("ConsumentId");

                    b.Navigation("Consument");
                });

            modelBuilder.Entity("DrinkingWoteApp_API.Models.Consument", b =>
                {
                    b.HasOne("DrinkingWoteApp_API.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("DrinkingWoteApp_API.Models.User", "User")
                        .WithOne("Consument")
                        .HasForeignKey("DrinkingWoteApp_API.Models.Consument", "UserId");

                    b.Navigation("Address");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DrinkingWoteApp_API.Models.Order", b =>
                {
                    b.HasOne("DrinkingWoteApp_API.Models.Bill", "Bill")
                        .WithMany()
                        .HasForeignKey("BillId");

                    b.HasOne("DrinkingWoteApp_API.Models.Consument", "Consument")
                        .WithMany("Orders")
                        .HasForeignKey("ConsumentId");

                    b.HasOne("DrinkingWoteApp_API.Models.CrewMember", "Crew")
                        .WithMany("Orders")
                        .HasForeignKey("CrewId");

                    b.HasOne("DrinkingWoteApp_API.Models.Review", "Review")
                        .WithMany()
                        .HasForeignKey("ReviewId");

                    b.Navigation("Bill");

                    b.Navigation("Consument");

                    b.Navigation("Crew");

                    b.Navigation("Review");
                });

            modelBuilder.Entity("DrinkingWoteApp_API.Models.Review", b =>
                {
                    b.HasOne("DrinkingWoteApp_API.Models.Consument", null)
                        .WithMany("Reviews")
                        .HasForeignKey("ConsumentId");

                    b.HasOne("DrinkingWoteApp_API.Models.CrewMember", "Crew")
                        .WithMany("Reviews")
                        .HasForeignKey("CrewId");

                    b.Navigation("Crew");
                });

            modelBuilder.Entity("DrinkingWoteApp_API.Models.Consument", b =>
                {
                    b.Navigation("Bills");

                    b.Navigation("Orders");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("DrinkingWoteApp_API.Models.CrewMember", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("DrinkingWoteApp_API.Models.User", b =>
                {
                    b.Navigation("Consument");
                });
#pragma warning restore 612, 618
        }
    }
}
