using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestaurantOnline.Migrations
{
    /// <inheritdoc />
    public partial class ChangeToICollectionInCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuPosition",
                keyColumn: "Id",
                keyValue: new Guid("33f1448f-6246-4b4d-9f47-3e8be9a08cc0"));

            migrationBuilder.DeleteData(
                table: "MenuPosition",
                keyColumn: "Id",
                keyValue: new Guid("3d676ee3-40f3-4031-84e7-36b82626218b"));

            migrationBuilder.DeleteData(
                table: "MenuPosition",
                keyColumn: "Id",
                keyValue: new Guid("955ee6ec-9cf4-4471-a00c-7afc012f4c63"));

            migrationBuilder.DeleteData(
                table: "MenuPosition",
                keyColumn: "Id",
                keyValue: new Guid("9bdc292f-5e0e-4aa4-96dd-e4596c9807ab"));

            migrationBuilder.DeleteData(
                table: "MenuPosition",
                keyColumn: "Id",
                keyValue: new Guid("bab6cc0f-fced-4e2a-8a03-7e6a2684e89e"));

            migrationBuilder.InsertData(
                table: "MenuPosition",
                columns: new[] { "Id", "CartId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("21996487-287d-4ee1-a44f-b0ef4924f36a"), null, "Soft drink", "Coca-cola", 5.0 },
                    { new Guid("a17df9ec-043c-44a0-aa9e-80f6030a9fc1"), null, "Most popular salat on the world", "Cesar Salat", 25.0 },
                    { new Guid("bdde8990-9eeb-4b0a-bc49-bee6ae144a33"), null, "Most popular pasta on the world", "Spaghetti", 31.0 },
                    { new Guid("d6a2037f-1b6c-47af-be5e-51a2d9ca438f"), null, "Simple pasta with eggs, bacon and parmeggiano", "Carbonara", 28.0 },
                    { new Guid("e263c28f-1f24-4b43-9d2a-8a6b166c63d5"), null, "Beer", "Johannes", 7.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuPosition",
                keyColumn: "Id",
                keyValue: new Guid("21996487-287d-4ee1-a44f-b0ef4924f36a"));

            migrationBuilder.DeleteData(
                table: "MenuPosition",
                keyColumn: "Id",
                keyValue: new Guid("a17df9ec-043c-44a0-aa9e-80f6030a9fc1"));

            migrationBuilder.DeleteData(
                table: "MenuPosition",
                keyColumn: "Id",
                keyValue: new Guid("bdde8990-9eeb-4b0a-bc49-bee6ae144a33"));

            migrationBuilder.DeleteData(
                table: "MenuPosition",
                keyColumn: "Id",
                keyValue: new Guid("d6a2037f-1b6c-47af-be5e-51a2d9ca438f"));

            migrationBuilder.DeleteData(
                table: "MenuPosition",
                keyColumn: "Id",
                keyValue: new Guid("e263c28f-1f24-4b43-9d2a-8a6b166c63d5"));

            migrationBuilder.InsertData(
                table: "MenuPosition",
                columns: new[] { "Id", "CartId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("33f1448f-6246-4b4d-9f47-3e8be9a08cc0"), null, "Most popular pasta on the world", "Spaghetti", 31.0 },
                    { new Guid("3d676ee3-40f3-4031-84e7-36b82626218b"), null, "Soft drink", "Coca-cola", 5.0 },
                    { new Guid("955ee6ec-9cf4-4471-a00c-7afc012f4c63"), null, "Simple pasta with eggs, bacon and parmeggiano", "Carbonara", 28.0 },
                    { new Guid("9bdc292f-5e0e-4aa4-96dd-e4596c9807ab"), null, "Beer", "Johannes", 7.0 },
                    { new Guid("bab6cc0f-fced-4e2a-8a03-7e6a2684e89e"), null, "Most popular salat on the world", "Cesar Salat", 25.0 }
                });
        }
    }
}
