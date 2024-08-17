using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddConstTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationConsts",
                columns: table => new
                {
                    ApplicationConstId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationConsts", x => x.ApplicationConstId);
                });

            migrationBuilder.UpdateData(
                table: "DifficultLevels",
                keyColumn: "DifficultLevelId",
                keyValue: new Guid("09593f78-2de4-48dc-9d79-72e72fa33607"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 17, 17, 2, 0, 181, DateTimeKind.Local).AddTicks(1728), new DateTime(2024, 8, 17, 17, 2, 0, 181, DateTimeKind.Local).AddTicks(1728) });

            migrationBuilder.UpdateData(
                table: "DifficultLevels",
                keyColumn: "DifficultLevelId",
                keyValue: new Guid("47bd5bef-43b8-48a1-8495-b2a09d2f1177"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 17, 17, 2, 0, 181, DateTimeKind.Local).AddTicks(1746), new DateTime(2024, 8, 17, 17, 2, 0, 181, DateTimeKind.Local).AddTicks(1747) });

            migrationBuilder.UpdateData(
                table: "DifficultLevels",
                keyColumn: "DifficultLevelId",
                keyValue: new Guid("5e0d9a7a-e16d-4e54-be4d-839fa04f5a37"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 17, 17, 2, 0, 181, DateTimeKind.Local).AddTicks(1711), new DateTime(2024, 8, 17, 17, 2, 0, 181, DateTimeKind.Local).AddTicks(1712) });

            migrationBuilder.UpdateData(
                table: "DifficultLevels",
                keyColumn: "DifficultLevelId",
                keyValue: new Guid("af69c0ce-a5d9-49b6-9c91-aec6bb73d27f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 17, 17, 2, 0, 181, DateTimeKind.Local).AddTicks(1648), new DateTime(2024, 8, 17, 17, 2, 0, 181, DateTimeKind.Local).AddTicks(1664) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationConsts");

            migrationBuilder.UpdateData(
                table: "DifficultLevels",
                keyColumn: "DifficultLevelId",
                keyValue: new Guid("09593f78-2de4-48dc-9d79-72e72fa33607"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 17, 16, 53, 19, 700, DateTimeKind.Local).AddTicks(4068), new DateTime(2024, 8, 17, 16, 53, 19, 700, DateTimeKind.Local).AddTicks(4069) });

            migrationBuilder.UpdateData(
                table: "DifficultLevels",
                keyColumn: "DifficultLevelId",
                keyValue: new Guid("47bd5bef-43b8-48a1-8495-b2a09d2f1177"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 17, 16, 53, 19, 700, DateTimeKind.Local).AddTicks(4099), new DateTime(2024, 8, 17, 16, 53, 19, 700, DateTimeKind.Local).AddTicks(4099) });

            migrationBuilder.UpdateData(
                table: "DifficultLevels",
                keyColumn: "DifficultLevelId",
                keyValue: new Guid("5e0d9a7a-e16d-4e54-be4d-839fa04f5a37"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 17, 16, 53, 19, 700, DateTimeKind.Local).AddTicks(4054), new DateTime(2024, 8, 17, 16, 53, 19, 700, DateTimeKind.Local).AddTicks(4054) });

            migrationBuilder.UpdateData(
                table: "DifficultLevels",
                keyColumn: "DifficultLevelId",
                keyValue: new Guid("af69c0ce-a5d9-49b6-9c91-aec6bb73d27f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 17, 16, 53, 19, 700, DateTimeKind.Local).AddTicks(3991), new DateTime(2024, 8, 17, 16, 53, 19, 700, DateTimeKind.Local).AddTicks(4005) });
        }
    }
}
