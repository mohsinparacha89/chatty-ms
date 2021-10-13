﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using chatty.Data;

namespace chatty.Migrations
{
    [DbContext(typeof(AirportContext))]
    [Migration("20210916080205_AddDutyRoaster")]
    partial class AddDutyRoaster
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("chatty.Models.AirportEvent", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AircraftType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Airline")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Event")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsInternational")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("AirportEvents");
                });

            modelBuilder.Entity("chatty.Models.DutyRoster", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Officer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Slot")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DutyRoasters");
                });
#pragma warning restore 612, 618
        }
    }
}
