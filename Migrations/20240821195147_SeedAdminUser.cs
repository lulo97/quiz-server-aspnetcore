using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdminUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Biography", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "Fullname", "ImageUrl", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[] { new Guid("1e874e00-f545-4a55-9a92-9a70afb606b0"), 0, null, "90885393-8aa7-40aa-8d91-3c0748e0b1bf", new DateTime(2024, 8, 22, 2, 51, 47, 25, DateTimeKind.Local).AddTicks(331), "luongpysl2@gmail.com", true, "admin", "https://lh3.googleusercontent.com/a/ACg8ocLV8p2S7WsFyfspBGUcvR-Nh2ojZP7d51i8NqdoPCq-jZ9PUP4=s432-c-no", false, null, "LUONGPYSL2@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAENRaPQ3fWOEGw4j9JbqcTGCQRHEJIDD9M/AvXrwxuKAK4FVP7tM06g6/3t2ss4lJzQ==", null, false, "415724b8-c1de-4d98-806a-e2378e3fdc14", false, new DateTime(2024, 8, 22, 2, 51, 47, 25, DateTimeKind.Local).AddTicks(332), "admin" });

            migrationBuilder.UpdateData(
                table: "DifficultLevels",
                keyColumn: "DifficultLevelId",
                keyValue: new Guid("09593f78-2de4-48dc-9d79-72e72fa33607"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 22, 2, 51, 47, 25, DateTimeKind.Local).AddTicks(268), new DateTime(2024, 8, 22, 2, 51, 47, 25, DateTimeKind.Local).AddTicks(268) });

            migrationBuilder.UpdateData(
                table: "DifficultLevels",
                keyColumn: "DifficultLevelId",
                keyValue: new Guid("47bd5bef-43b8-48a1-8495-b2a09d2f1177"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 22, 2, 51, 47, 25, DateTimeKind.Local).AddTicks(284), new DateTime(2024, 8, 22, 2, 51, 47, 25, DateTimeKind.Local).AddTicks(285) });

            migrationBuilder.UpdateData(
                table: "DifficultLevels",
                keyColumn: "DifficultLevelId",
                keyValue: new Guid("5e0d9a7a-e16d-4e54-be4d-839fa04f5a37"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 22, 2, 51, 47, 25, DateTimeKind.Local).AddTicks(252), new DateTime(2024, 8, 22, 2, 51, 47, 25, DateTimeKind.Local).AddTicks(252) });

            migrationBuilder.UpdateData(
                table: "DifficultLevels",
                keyColumn: "DifficultLevelId",
                keyValue: new Guid("af69c0ce-a5d9-49b6-9c91-aec6bb73d27f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 22, 2, 51, 47, 25, DateTimeKind.Local).AddTicks(177), new DateTime(2024, 8, 22, 2, 51, 47, 25, DateTimeKind.Local).AddTicks(191) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1e874e00-f545-4a55-9a92-9a70afb606b0"));

            migrationBuilder.UpdateData(
                table: "DifficultLevels",
                keyColumn: "DifficultLevelId",
                keyValue: new Guid("09593f78-2de4-48dc-9d79-72e72fa33607"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 21, 22, 46, 30, 193, DateTimeKind.Local).AddTicks(3671), new DateTime(2024, 8, 21, 22, 46, 30, 193, DateTimeKind.Local).AddTicks(3671) });

            migrationBuilder.UpdateData(
                table: "DifficultLevels",
                keyColumn: "DifficultLevelId",
                keyValue: new Guid("47bd5bef-43b8-48a1-8495-b2a09d2f1177"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 21, 22, 46, 30, 193, DateTimeKind.Local).AddTicks(3686), new DateTime(2024, 8, 21, 22, 46, 30, 193, DateTimeKind.Local).AddTicks(3686) });

            migrationBuilder.UpdateData(
                table: "DifficultLevels",
                keyColumn: "DifficultLevelId",
                keyValue: new Guid("5e0d9a7a-e16d-4e54-be4d-839fa04f5a37"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 21, 22, 46, 30, 193, DateTimeKind.Local).AddTicks(3654), new DateTime(2024, 8, 21, 22, 46, 30, 193, DateTimeKind.Local).AddTicks(3655) });

            migrationBuilder.UpdateData(
                table: "DifficultLevels",
                keyColumn: "DifficultLevelId",
                keyValue: new Guid("af69c0ce-a5d9-49b6-9c91-aec6bb73d27f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 21, 22, 46, 30, 193, DateTimeKind.Local).AddTicks(3585), new DateTime(2024, 8, 21, 22, 46, 30, 193, DateTimeKind.Local).AddTicks(3598) });
        }
    }
}
