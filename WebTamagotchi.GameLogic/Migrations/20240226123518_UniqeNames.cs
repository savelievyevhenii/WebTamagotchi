using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebTamagotchi.GameLogic.Migrations
{
    /// <inheritdoc />
    public partial class UniqeNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bathrooms",
                keyColumn: "Id",
                keyValue: "6b48c7ea-efe3-4026-87ff-3e0f14042e5b");

            migrationBuilder.DeleteData(
                table: "Bedrooms",
                keyColumn: "Id",
                keyValue: "f0d4a96b-4e98-4a5c-951f-24e04732dd29");

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: "ad6f8364-f5de-4dbf-bba3-cd6d7f0946e2");

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: "dbe4dc7b-f42f-4954-9457-cf750e243d9e");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "fc0ac1b8-eeb1-4ecc-9401-9a82ed3ceae5");

            migrationBuilder.InsertData(
                table: "Bathrooms",
                columns: new[] { "Id", "Cleanliness", "Experience", "Name" },
                values: new object[] { "75ebe049-5978-415c-a2e2-887d9d3ddf89", 20, 20, "Standard Bathroom" });

            migrationBuilder.InsertData(
                table: "Bedrooms",
                columns: new[] { "Id", "Energy", "Experience", "Name" },
                values: new object[] { "173da4ae-41fa-43c1-8c6f-8e93cbb6fb8b", 20, 20, "Standard Bedroom" });

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "Id", "Dirtiness", "Experience", "Name", "Satiety" },
                values: new object[,]
                {
                    { "3e5e4e81-6af7-4dd0-a117-ed7f4b010961", 12, 20, "Soup", 26 },
                    { "ef664ac6-f27c-4bba-8c6e-1162f66f72b6", 6, 10, "Apple", 10 }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Dirtiness", "Experience", "Fun", "Hunger", "Name", "Tiredness" },
                values: new object[] { "71c82515-0a59-4f44-a49b-98cc8bc990bf", 10, 20, 10, 16, "TestGame", 20 });

            migrationBuilder.CreateIndex(
                name: "IX_Games_Name",
                table: "Games",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Foods_Name",
                table: "Foods",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bedrooms_Name",
                table: "Bedrooms",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bathrooms_Name",
                table: "Bathrooms",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Games_Name",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Foods_Name",
                table: "Foods");

            migrationBuilder.DropIndex(
                name: "IX_Bedrooms_Name",
                table: "Bedrooms");

            migrationBuilder.DropIndex(
                name: "IX_Bathrooms_Name",
                table: "Bathrooms");

            migrationBuilder.DeleteData(
                table: "Bathrooms",
                keyColumn: "Id",
                keyValue: "75ebe049-5978-415c-a2e2-887d9d3ddf89");

            migrationBuilder.DeleteData(
                table: "Bedrooms",
                keyColumn: "Id",
                keyValue: "173da4ae-41fa-43c1-8c6f-8e93cbb6fb8b");

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: "3e5e4e81-6af7-4dd0-a117-ed7f4b010961");

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: "ef664ac6-f27c-4bba-8c6e-1162f66f72b6");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "71c82515-0a59-4f44-a49b-98cc8bc990bf");

            migrationBuilder.InsertData(
                table: "Bathrooms",
                columns: new[] { "Id", "Cleanliness", "Experience", "Name" },
                values: new object[] { "6b48c7ea-efe3-4026-87ff-3e0f14042e5b", 20, 20, "Standard Bathroom" });

            migrationBuilder.InsertData(
                table: "Bedrooms",
                columns: new[] { "Id", "Energy", "Experience", "Name" },
                values: new object[] { "f0d4a96b-4e98-4a5c-951f-24e04732dd29", 20, 20, "Standard Bedroom" });

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "Id", "Dirtiness", "Experience", "Name", "Satiety" },
                values: new object[,]
                {
                    { "ad6f8364-f5de-4dbf-bba3-cd6d7f0946e2", 12, 20, "Soup", 26 },
                    { "dbe4dc7b-f42f-4954-9457-cf750e243d9e", 6, 10, "Apple", 10 }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Dirtiness", "Experience", "Fun", "Hunger", "Name", "Tiredness" },
                values: new object[] { "fc0ac1b8-eeb1-4ecc-9401-9a82ed3ceae5", 10, 20, 10, 16, "TestGame", 20 });
        }
    }
}
