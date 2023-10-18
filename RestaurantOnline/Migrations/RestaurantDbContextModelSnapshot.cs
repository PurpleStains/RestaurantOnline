﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestaurantOnline.DatabaseContext;

#nullable disable

namespace RestaurantOnline.Migrations
{
    [DbContext(typeof(RestaurantDbContext))]
    partial class RestaurantDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RestaurantOnline.Models.Cart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("RestaurantOnline.Models.CustomerOrder", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CartId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.ToTable("CustomerOrder");
                });

            modelBuilder.Entity("RestaurantOnline.Models.MenuPosition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CartId")
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

                    b.HasIndex("CartId");

                    b.ToTable("MenuPosition");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a17df9ec-043c-44a0-aa9e-80f6030a9fc1"),
                            Description = "Most popular salat on the world",
                            Name = "Cesar Salat",
                            Price = 25.0
                        },
                        new
                        {
                            Id = new Guid("bdde8990-9eeb-4b0a-bc49-bee6ae144a33"),
                            Description = "Most popular pasta on the world",
                            Name = "Spaghetti",
                            Price = 31.0
                        },
                        new
                        {
                            Id = new Guid("d6a2037f-1b6c-47af-be5e-51a2d9ca438f"),
                            Description = "Simple pasta with eggs, bacon and parmeggiano",
                            Name = "Carbonara",
                            Price = 28.0
                        },
                        new
                        {
                            Id = new Guid("21996487-287d-4ee1-a44f-b0ef4924f36a"),
                            Description = "Soft drink",
                            Name = "Coca-cola",
                            Price = 5.0
                        },
                        new
                        {
                            Id = new Guid("e263c28f-1f24-4b43-9d2a-8a6b166c63d5"),
                            Description = "Beer",
                            Name = "Johannes",
                            Price = 7.0
                        });
                });

            modelBuilder.Entity("RestaurantOnline.Models.CustomerOrder", b =>
                {
                    b.HasOne("RestaurantOnline.Models.Cart", "Cart")
                        .WithMany()
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");
                });

            modelBuilder.Entity("RestaurantOnline.Models.MenuPosition", b =>
                {
                    b.HasOne("RestaurantOnline.Models.Cart", null)
                        .WithMany("ToOrder")
                        .HasForeignKey("CartId");
                });

            modelBuilder.Entity("RestaurantOnline.Models.Cart", b =>
                {
                    b.Navigation("ToOrder");
                });
#pragma warning restore 612, 618
        }
    }
}
