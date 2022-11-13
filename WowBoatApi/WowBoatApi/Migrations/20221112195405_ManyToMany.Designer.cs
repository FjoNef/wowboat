﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WowBoatApi.DAL;

#nullable disable

namespace WowBoatApi.Migrations
{
    [DbContext(typeof(WowBoatDbContext))]
    [Migration("20221112195405_ManyToMany")]
    partial class ManyToMany
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BoatBenefitBoatInformation", b =>
                {
                    b.Property<int>("BenefitsId")
                        .HasColumnType("int");

                    b.Property<int>("BoatsId")
                        .HasColumnType("int");

                    b.HasKey("BenefitsId", "BoatsId");

                    b.HasIndex("BoatsId");

                    b.ToTable("BoatBenefitBoatInformation");
                });

            modelBuilder.Entity("WowBoatApi.DAL.BoatBenefit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BoatBenefits");
                });

            modelBuilder.Entity("WowBoatApi.DAL.BoatImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BoatInformationId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BoatInformationId");

                    b.ToTable("BoatImages");
                });

            modelBuilder.Entity("WowBoatApi.DAL.BoatInformation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BoatTypeId")
                        .HasColumnType("int");

                    b.Property<bool>("CaptainAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<int>("MaxCapacity")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RoomsCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BoatTypeId");

                    b.HasIndex("LocationId");

                    b.ToTable("BoatsInformation");
                });

            modelBuilder.Entity("WowBoatApi.DAL.BoatLocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BoatLocations");
                });

            modelBuilder.Entity("WowBoatApi.DAL.BoatType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BoatTypes");
                });

            modelBuilder.Entity("BoatBenefitBoatInformation", b =>
                {
                    b.HasOne("WowBoatApi.DAL.BoatBenefit", null)
                        .WithMany()
                        .HasForeignKey("BenefitsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WowBoatApi.DAL.BoatInformation", null)
                        .WithMany()
                        .HasForeignKey("BoatsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WowBoatApi.DAL.BoatImage", b =>
                {
                    b.HasOne("WowBoatApi.DAL.BoatInformation", null)
                        .WithMany("Images")
                        .HasForeignKey("BoatInformationId");
                });

            modelBuilder.Entity("WowBoatApi.DAL.BoatInformation", b =>
                {
                    b.HasOne("WowBoatApi.DAL.BoatType", "BoatType")
                        .WithMany()
                        .HasForeignKey("BoatTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WowBoatApi.DAL.BoatLocation", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BoatType");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("WowBoatApi.DAL.BoatInformation", b =>
                {
                    b.Navigation("Images");
                });
#pragma warning restore 612, 618
        }
    }
}