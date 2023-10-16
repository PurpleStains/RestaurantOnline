﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestaurantOnline.DatabaseContext;

#nullable disable

namespace RestaurantOnline.Migrations
{
    [DbContext(typeof(RestaurantDbContext))]
    [Migration("20231016201538_AddInitialDataToMenuPosition")]
    partial class AddInitialDataToMenuPosition
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RestaurantOnline.Models.MenuPosition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("MenuPosition");

                    b.HasData(
                        new
                        {
                            Id = new Guid("995f290a-a774-48a1-81ba-15b3c3bd97ca"),
                            Description = "Most popular salat on the world",
                            Name = "Cesar Salat",
                            Price = 25.0
                        },
                        new
                        {
                            Id = new Guid("df5cba23-26ec-4ba2-b993-80f34b47eaa2"),
                            Description = "Most popular pasta on the world",
                            Name = "Spaghetti",
                            Price = 31.0
                        },
                        new
                        {
                            Id = new Guid("5f082374-37d2-491b-ba4b-eb9060821042"),
                            Description = "Simple pasta with eggs, bacon and parmeggiano",
                            Name = "Carbonara",
                            Price = 28.0
                        },
                        new
                        {
                            Id = new Guid("5c206fa9-9d7b-492f-bc2a-39f8bc14d83c"),
                            Description = "Soft drink",
                            Name = "Coca-cola",
                            Price = 5.0
                        },
                        new
                        {
                            Id = new Guid("f90abae8-a8e1-4dd8-888e-27bba4df3654"),
                            Description = "Beer",
                            Name = "Johannes",
                            Price = 7.0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
