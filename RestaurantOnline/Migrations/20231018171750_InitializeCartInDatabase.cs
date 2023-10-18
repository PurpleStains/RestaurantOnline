using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestaurantOnline.Migrations
{
    /// <inheritdoc />
    public partial class InitializeCartInDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "CartId",
                table: "MenuPosition",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "MenuPosition",
                columns: new[] { "Id", "CartId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("0bd92575-4981-4020-8c7f-e539a5937952"), null, "Beer", "Johannes", 7.0 },
                    { new Guid("13757aac-0114-4f18-b8ed-f5c934d81326"), null, "Most popular pasta on the world", "Spaghetti", 31.0 },
                    { new Guid("c9bf0f18-9751-43cf-b186-37ca5f95ec31"), null, "Most popular salat on the world", "Cesar Salat", 25.0 },
                    { new Guid("e3ab842b-87f8-4ff2-ab7a-0fb9378484b8"), null, "Soft drink", "Coca-cola", 5.0 },
                    { new Guid("f41ff707-8f33-4e1b-88b2-2991e7ab84a4"), null, "Simple pasta with eggs, bacon and parmeggiano", "Carbonara", 28.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuPosition_CartId",
                table: "MenuPosition",
                column: "CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuPosition_Cart_CartId",
                table: "MenuPosition",
                column: "CartId",
                principalTable: "Cart",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuPosition_Cart_CartId",
                table: "MenuPosition");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropIndex(
                name: "IX_MenuPosition_CartId",
                table: "MenuPosition");

            migrationBuilder.DeleteData(
                table: "MenuPosition",
                keyColumn: "Id",
                keyValue: new Guid("0bd92575-4981-4020-8c7f-e539a5937952"));

            migrationBuilder.DeleteData(
                table: "MenuPosition",
                keyColumn: "Id",
                keyValue: new Guid("13757aac-0114-4f18-b8ed-f5c934d81326"));

            migrationBuilder.DeleteData(
                table: "MenuPosition",
                keyColumn: "Id",
                keyValue: new Guid("c9bf0f18-9751-43cf-b186-37ca5f95ec31"));

            migrationBuilder.DeleteData(
                table: "MenuPosition",
                keyColumn: "Id",
                keyValue: new Guid("e3ab842b-87f8-4ff2-ab7a-0fb9378484b8"));

            migrationBuilder.DeleteData(
                table: "MenuPosition",
                keyColumn: "Id",
                keyValue: new Guid("f41ff707-8f33-4e1b-88b2-2991e7ab84a4"));

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "MenuPosition");

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
    }
}
