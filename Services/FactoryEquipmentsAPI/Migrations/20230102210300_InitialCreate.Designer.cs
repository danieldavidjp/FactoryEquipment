﻿// <auto-generated />
using System;
using FactoryEquipmentsAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FactoryEquipmentsAPI.Migrations
{
    [DbContext(typeof(FactoryEquipmentContext))]
    [Migration("20230102210300_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FactoryEquipmentsAPI.Models.Equipment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Equipment");
                });

            modelBuilder.Entity("FactoryEquipmentsAPI.Models.Schedule", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("EquipmentId")
                        .HasColumnType("uuid");

                    b.Property<string>("State")
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("EquipmentId");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("FactoryEquipmentsAPI.Models.StatusLog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("EquipmentId")
                        .HasColumnType("uuid");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("EquipmentId");

                    b.ToTable("StatusLogs");
                });

            modelBuilder.Entity("FactoryEquipmentsAPI.Models.Schedule", b =>
                {
                    b.HasOne("FactoryEquipmentsAPI.Models.Equipment", "Equipment")
                        .WithMany("Schedules")
                        .HasForeignKey("EquipmentId");

                    b.Navigation("Equipment");
                });

            modelBuilder.Entity("FactoryEquipmentsAPI.Models.StatusLog", b =>
                {
                    b.HasOne("FactoryEquipmentsAPI.Models.Equipment", "Equipment")
                        .WithMany("StatusLogs")
                        .HasForeignKey("EquipmentId");

                    b.Navigation("Equipment");
                });

            modelBuilder.Entity("FactoryEquipmentsAPI.Models.Equipment", b =>
                {
                    b.Navigation("Schedules");

                    b.Navigation("StatusLogs");
                });
#pragma warning restore 612, 618
        }
    }
}
