using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebTamagotchi.GameLogic.Migrations
{
    /// <inheritdoc />
    public partial class RemoveIcons : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bathrooms",
                keyColumn: "Id",
                keyValue: "0100efb3-a489-4dc5-b33f-3f4acd5c0766");

            migrationBuilder.DeleteData(
                table: "Bedrooms",
                keyColumn: "Id",
                keyValue: "c2a994dc-77f2-4733-8b10-73b01b787695");

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: "2486f252-4ee6-4805-82ad-f723bbebe670");

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: "905e8cdf-8e84-441b-98d2-cb9b3d98c548");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "cf619653-3c19-49a1-9790-23ba30458dad");

            migrationBuilder.DropColumn(
                name: "IconJson",
                table: "Foods");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "IconJson",
                table: "Foods",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Bathrooms",
                columns: new[] { "Id", "Cleanliness", "Experience", "Name" },
                values: new object[] { "0100efb3-a489-4dc5-b33f-3f4acd5c0766", 20, 20, "Standard Bathroom" });

            migrationBuilder.InsertData(
                table: "Bedrooms",
                columns: new[] { "Id", "Energy", "Experience", "Name" },
                values: new object[] { "c2a994dc-77f2-4733-8b10-73b01b787695", 20, 20, "Standard Bedroom" });

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "Id", "Dirtiness", "Experience", "IconJson", "Name", "Satiety" },
                values: new object[,]
                {
                    { "2486f252-4ee6-4805-82ad-f723bbebe670", 12, 20, "icon", "Soup", 26 },
                    { "905e8cdf-8e84-441b-98d2-cb9b3d98c548", 6, 10, "icon", "Apple", 10 }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Dirtiness", "Experience", "Fun", "Hunger", "Name", "Tiredness" },
                values: new object[] { "cf619653-3c19-49a1-9790-23ba30458dad", 10, 20, 10, 16, "TestGame", 20 });
        }
    }
}
