using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestaurantOnline.Migrations
{
    /// <inheritdoc />
    public partial class InitializeCustomerOdererTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "CustomerOrder",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerOrder_Cart_CartId",
                        column: x => x.CartId,
                        principalTable: "Cart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOrder_CartId",
                table: "CustomerOrder",
                column: "CartId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerOrder");

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
                    { new Guid("0bd92575-4981-4020-8c7f-e539a5937952"), null, "Beer", "Johannes", 7.0 },
                    { new Guid("13757aac-0114-4f18-b8ed-f5c934d81326"), null, "Most popular pasta on the world", "Spaghetti", 31.0 },
                    { new Guid("c9bf0f18-9751-43cf-b186-37ca5f95ec31"), null, "Most popular salat on the world", "Cesar Salat", 25.0 },
                    { new Guid("e3ab842b-87f8-4ff2-ab7a-0fb9378484b8"), null, "Soft drink", "Coca-cola", 5.0 },
                    { new Guid("f41ff707-8f33-4e1b-88b2-2991e7ab84a4"), null, "Simple pasta with eggs, bacon and parmeggiano", "Carbonara", 28.0 }
                });
        }
    }
}
