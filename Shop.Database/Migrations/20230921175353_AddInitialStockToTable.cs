using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Database.Migrations
{
    public partial class AddInitialStockToTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Stock",
                columns: new[] { "Id", "Description", "ProductId", "Qty" },
                values: new object[] { 1, "Coś tam", 1, 3 });

            migrationBuilder.InsertData(
                table: "Stock",
                columns: new[] { "Id", "Description", "ProductId", "Qty" },
                values: new object[] { 2, "Coś tam", 2, 10 });

            migrationBuilder.InsertData(
                table: "Stock",
                columns: new[] { "Id", "Description", "ProductId", "Qty" },
                values: new object[] { 3, "Coś tam", 3, 10 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Stock",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Stock",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Stock",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
