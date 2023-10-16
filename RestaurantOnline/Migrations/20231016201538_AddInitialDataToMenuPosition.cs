using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestaurantOnline.Migrations
{
    /// <inheritdoc />
    public partial class AddInitialDataToMenuPosition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MenuPosition",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("5c206fa9-9d7b-492f-bc2a-39f8bc14d83c"), "Soft drink", "Coca-cola", 5.0 },
                    { new Guid("5f082374-37d2-491b-ba4b-eb9060821042"), "Simple pasta with eggs, bacon and parmeggiano", "Carbonara", 28.0 },
                    { new Guid("995f290a-a774-48a1-81ba-15b3c3bd97ca"), "Most popular salat on the world", "Cesar Salat", 25.0 },
                    { new Guid("df5cba23-26ec-4ba2-b993-80f34b47eaa2"), "Most popular pasta on the world", "Spaghetti", 31.0 },
                    { new Guid("f90abae8-a8e1-4dd8-888e-27bba4df3654"), "Beer", "Johannes", 7.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuPosition",
                keyColumn: "Id",
                keyValue: new Guid("5c206fa9-9d7b-492f-bc2a-39f8bc14d83c"));

            migrationBuilder.DeleteData(
                table: "MenuPosition",
                keyColumn: "Id",
                keyValue: new Guid("5f082374-37d2-491b-ba4b-eb9060821042"));

            migrationBuilder.DeleteData(
                table: "MenuPosition",
                keyColumn: "Id",
                keyValue: new Guid("995f290a-a774-48a1-81ba-15b3c3bd97ca"));

            migrationBuilder.DeleteData(
                table: "MenuPosition",
                keyColumn: "Id",
                keyValue: new Guid("df5cba23-26ec-4ba2-b993-80f34b47eaa2"));

            migrationBuilder.DeleteData(
                table: "MenuPosition",
                keyColumn: "Id",
                keyValue: new Guid("f90abae8-a8e1-4dd8-888e-27bba4df3654"));
        }
    }
}
