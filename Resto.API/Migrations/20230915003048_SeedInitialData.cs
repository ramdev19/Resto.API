using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Resto.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("6e1305b1-56ae-4e2b-8ed0-6783983b0901"), "Shaka" });

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "Id", "FoodDescription", "FoodName", "FoodPrice" },
                values: new object[,]
                {
                    { new Guid("02f1a833-c09a-42a5-a459-e5aad275d806"), "Main Menu", "Chicken Crispy", 75000m },
                    { new Guid("889964ae-3c02-4b98-8695-8b45d1e5904c"), "Appetizer", "Fried Potato", 35000m },
                    { new Guid("b542e7c7-8558-41e4-b516-e87cd420102c"), "Main Menu", "Bakar Bumbu Asap", 298000m },
                    { new Guid("cc773bcc-8eda-4228-92ec-5b09361dd9f1"), "Appetizer", "Fried Mantau", 22000m },
                    { new Guid("e1acf2f6-2a21-427c-a1ee-d3442664004b"), "Main Men", "Butter Garlic Sauce", 298000m },
                    { new Guid("eb920cd4-dfe1-4c75-a3f8-fc6bf86a2b02"), "Vegetable", "Tumis Tauge Kecap", 235000m },
                    { new Guid("ed45ffaf-f684-4e5b-9508-d6fc930d44fc"), "Main Menu", "Singapore Chilli Sauce", 235000m }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CustomerId", "OrderDate", "TotalPayment" },
                values: new object[] { 1, new Guid("6e1305b1-56ae-4e2b-8ed0-6783983b0901"), new DateTime(2023, 9, 15, 7, 30, 48, 214, DateTimeKind.Local).AddTicks(1076), 298000m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("6e1305b1-56ae-4e2b-8ed0-6783983b0901"));

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: new Guid("02f1a833-c09a-42a5-a459-e5aad275d806"));

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: new Guid("889964ae-3c02-4b98-8695-8b45d1e5904c"));

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: new Guid("b542e7c7-8558-41e4-b516-e87cd420102c"));

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: new Guid("cc773bcc-8eda-4228-92ec-5b09361dd9f1"));

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: new Guid("e1acf2f6-2a21-427c-a1ee-d3442664004b"));

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: new Guid("eb920cd4-dfe1-4c75-a3f8-fc6bf86a2b02"));

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: new Guid("ed45ffaf-f684-4e5b-9508-d6fc930d44fc"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1);
        }
    }
}
