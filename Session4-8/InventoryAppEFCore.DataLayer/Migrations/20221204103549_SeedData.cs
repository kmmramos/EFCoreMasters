using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryAppEFCore.DataLayer.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "IsDeleted", "Name" },
                values: new object[] { 1, false, "White Dress" });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "SupplierId", "Description", "Name" },
                values: new object[] { 1, "A large department store", "SM Department Store" });

            migrationBuilder.InsertData(
                table: "Tags",
                column: "TagId",
                value: "Clothes");

            migrationBuilder.InsertData(
                table: "PriceOffers",
                columns: new[] { "PriceOfferId", "NewPrice", "ProductId", "PromotinalText" },
                values: new object[] { 1, 100m, 1, "Christmas Promo" });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "Comment", "NumStars", "ProductId", "VoterName" },
                values: new object[] { 1, "The dress looks flowy!", 4, 1, "Voter Name 1" });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "Comment", "NumStars", "ProductId", "VoterName" },
                values: new object[] { 2, "The dress is too big!", 5, 1, "Voter Name 2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PriceOffers",
                keyColumn: "PriceOfferId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: "Clothes");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);
        }
    }
}
