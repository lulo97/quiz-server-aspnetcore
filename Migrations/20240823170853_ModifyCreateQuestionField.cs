using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class ModifyCreateQuestionField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EducationLevelId",
                table: "Questions",
                newName: "BookId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1e874e00-f545-4a55-9a92-9a70afb606b0"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "3c324c8b-7323-425e-853a-1188f39f38ec", new DateTime(2024, 8, 24, 0, 8, 53, 441, DateTimeKind.Local).AddTicks(335), "AQAAAAIAAYagAAAAEDwB4Atw9diWtvRXXS9Yoz+OnF+F2eleZInkvk1+abhnUiapdVWAoG0SEL4SOKs8Uw==", "75a365aa-5e32-4f29-bcfe-536a8474c3e3", new DateTime(2024, 8, 24, 0, 8, 53, 441, DateTimeKind.Local).AddTicks(336) });

            migrationBuilder.UpdateData(
                table: "DifficultLevels",
                keyColumn: "DifficultLevelId",
                keyValue: new Guid("09593f78-2de4-48dc-9d79-72e72fa33607"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 24, 0, 8, 53, 441, DateTimeKind.Local).AddTicks(268), new DateTime(2024, 8, 24, 0, 8, 53, 441, DateTimeKind.Local).AddTicks(269) });

            migrationBuilder.UpdateData(
                table: "DifficultLevels",
                keyColumn: "DifficultLevelId",
                keyValue: new Guid("47bd5bef-43b8-48a1-8495-b2a09d2f1177"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 24, 0, 8, 53, 441, DateTimeKind.Local).AddTicks(282), new DateTime(2024, 8, 24, 0, 8, 53, 441, DateTimeKind.Local).AddTicks(283) });

            migrationBuilder.UpdateData(
                table: "DifficultLevels",
                keyColumn: "DifficultLevelId",
                keyValue: new Guid("5e0d9a7a-e16d-4e54-be4d-839fa04f5a37"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 24, 0, 8, 53, 441, DateTimeKind.Local).AddTicks(251), new DateTime(2024, 8, 24, 0, 8, 53, 441, DateTimeKind.Local).AddTicks(252) });

            migrationBuilder.UpdateData(
                table: "DifficultLevels",
                keyColumn: "DifficultLevelId",
                keyValue: new Guid("af69c0ce-a5d9-49b6-9c91-aec6bb73d27f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 24, 0, 8, 53, 441, DateTimeKind.Local).AddTicks(189), new DateTime(2024, 8, 24, 0, 8, 53, 441, DateTimeKind.Local).AddTicks(203) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "Questions",
                newName: "EducationLevelId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1e874e00-f545-4a55-9a92-9a70afb606b0"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "90885393-8aa7-40aa-8d91-3c0748e0b1bf", new DateTime(2024, 8, 22, 2, 51, 47, 25, DateTimeKind.Local).AddTicks(331), "AQAAAAIAAYagAAAAENRaPQ3fWOEGw4j9JbqcTGCQRHEJIDD9M/AvXrwxuKAK4FVP7tM06g6/3t2ss4lJzQ==", "415724b8-c1de-4d98-806a-e2378e3fdc14", new DateTime(2024, 8, 22, 2, 51, 47, 25, DateTimeKind.Local).AddTicks(332) });

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
    }
}
