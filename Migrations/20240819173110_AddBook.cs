using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Points_Value",
                table: "Points");

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                });

            migrationBuilder.UpdateData(
                table: "DifficultLevels",
                keyColumn: "DifficultLevelId",
                keyValue: new Guid("09593f78-2de4-48dc-9d79-72e72fa33607"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 20, 0, 31, 10, 200, DateTimeKind.Local).AddTicks(736), new DateTime(2024, 8, 20, 0, 31, 10, 200, DateTimeKind.Local).AddTicks(736) });

            migrationBuilder.UpdateData(
                table: "DifficultLevels",
                keyColumn: "DifficultLevelId",
                keyValue: new Guid("47bd5bef-43b8-48a1-8495-b2a09d2f1177"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 20, 0, 31, 10, 200, DateTimeKind.Local).AddTicks(751), new DateTime(2024, 8, 20, 0, 31, 10, 200, DateTimeKind.Local).AddTicks(751) });

            migrationBuilder.UpdateData(
                table: "DifficultLevels",
                keyColumn: "DifficultLevelId",
                keyValue: new Guid("5e0d9a7a-e16d-4e54-be4d-839fa04f5a37"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 20, 0, 31, 10, 200, DateTimeKind.Local).AddTicks(719), new DateTime(2024, 8, 20, 0, 31, 10, 200, DateTimeKind.Local).AddTicks(720) });

            migrationBuilder.UpdateData(
                table: "DifficultLevels",
                keyColumn: "DifficultLevelId",
                keyValue: new Guid("af69c0ce-a5d9-49b6-9c91-aec6bb73d27f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 20, 0, 31, 10, 200, DateTimeKind.Local).AddTicks(656), new DateTime(2024, 8, 20, 0, 31, 10, 200, DateTimeKind.Local).AddTicks(667) });

            migrationBuilder.CreateIndex(
                name: "IX_Points_Value_IsPenalty",
                table: "Points",
                columns: new[] { "Value", "IsPenalty" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_Name",
                table: "Books",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Points_Value_IsPenalty",
                table: "Points");

            migrationBuilder.UpdateData(
                table: "DifficultLevels",
                keyColumn: "DifficultLevelId",
                keyValue: new Guid("09593f78-2de4-48dc-9d79-72e72fa33607"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 17, 23, 53, 37, 533, DateTimeKind.Local).AddTicks(5227), new DateTime(2024, 8, 17, 23, 53, 37, 533, DateTimeKind.Local).AddTicks(5227) });

            migrationBuilder.UpdateData(
                table: "DifficultLevels",
                keyColumn: "DifficultLevelId",
                keyValue: new Guid("47bd5bef-43b8-48a1-8495-b2a09d2f1177"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 17, 23, 53, 37, 533, DateTimeKind.Local).AddTicks(5241), new DateTime(2024, 8, 17, 23, 53, 37, 533, DateTimeKind.Local).AddTicks(5242) });

            migrationBuilder.UpdateData(
                table: "DifficultLevels",
                keyColumn: "DifficultLevelId",
                keyValue: new Guid("5e0d9a7a-e16d-4e54-be4d-839fa04f5a37"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 17, 23, 53, 37, 533, DateTimeKind.Local).AddTicks(5211), new DateTime(2024, 8, 17, 23, 53, 37, 533, DateTimeKind.Local).AddTicks(5212) });

            migrationBuilder.UpdateData(
                table: "DifficultLevels",
                keyColumn: "DifficultLevelId",
                keyValue: new Guid("af69c0ce-a5d9-49b6-9c91-aec6bb73d27f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 17, 23, 53, 37, 533, DateTimeKind.Local).AddTicks(5116), new DateTime(2024, 8, 17, 23, 53, 37, 533, DateTimeKind.Local).AddTicks(5128) });

            migrationBuilder.CreateIndex(
                name: "IX_Points_Value",
                table: "Points",
                column: "Value",
                unique: true);
        }
    }
}
