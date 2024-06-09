using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shofyi.Migrations
{
    public partial class IdentityTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Image", "Name", "SoftDeleted" },
                values: new object[,]
                {
                    { 1, "headphone-category.png", "Headphones", false },
                    { 2, "mobile-category.png", "Mobile Tablets", false },
                    { 3, "pc-category.png", "CPU Heat Pipes", false },
                    { 4, "watch-category.png", "Smart Watch", false },
                    { 5, "acces-category.png", "Bluetooth", false }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
