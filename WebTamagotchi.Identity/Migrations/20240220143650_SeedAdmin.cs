using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebTamagotchi.Identity.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "80c8b6b1-e2b6-45e8-b044-8f2178a90111", 0, "0abdb33a-f380-4dd0-a3d2-43e42de761cc", "admin@webtamagotchi.com", false, false, null, "ADMIN@WEBTAMAGOTCHI.COM", "ADMIN@WEBTAMAGOTCHI.COM", "AQAAAAIAAYagAAAAEMkpGs9WJAZco2YpkXD4R8txAI8qW3jaGJbE8oNYOpv5M5qrKg5ubWPI1VBfKIAN4Q==", null, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "b5ebbb13-bc66-49b1-ae35-8966ca7f1db8", false, "admin@webtamagotchi.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80c8b6b1-e2b6-45e8-b044-8f2178a90111");
        }
    }
}
