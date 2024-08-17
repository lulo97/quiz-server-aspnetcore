using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class TestSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DifficultLevels",
                columns: new[] { "DifficultLevelId", "CreatedAt", "Description", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("09593f78-2de4-48dc-9d79-72e72fa33607"), new DateTime(2024, 8, 17, 16, 53, 19, 700, DateTimeKind.Local).AddTicks(4068), "Biết vận dụng kiến thức, kĩ năng đã học để giải quyết những vấn dề quen thuộc, tương tự trong học tập, cuộc sống.", "Vận dụng", new DateTime(2024, 8, 17, 16, 53, 19, 700, DateTimeKind.Local).AddTicks(4069) },
                    { new Guid("47bd5bef-43b8-48a1-8495-b2a09d2f1177"), new DateTime(2024, 8, 17, 16, 53, 19, 700, DateTimeKind.Local).AddTicks(4099), "Vận dụng các kiến thức, kĩ năng đã học để giải quyết vấn đề mới hoặc đưa ra những phản hồi hợp lý trong học tập, cuộc sống một cách linh hoạt.", "Vận dụng cao", new DateTime(2024, 8, 17, 16, 53, 19, 700, DateTimeKind.Local).AddTicks(4099) },
                    { new Guid("5e0d9a7a-e16d-4e54-be4d-839fa04f5a37"), new DateTime(2024, 8, 17, 16, 53, 19, 700, DateTimeKind.Local).AddTicks(4054), "Hiểu kiến thức, kĩ năng đã học. trình bày, giải thích được kiến thức theo cách hiểu của cá nhân.", "Đọc hiểu", new DateTime(2024, 8, 17, 16, 53, 19, 700, DateTimeKind.Local).AddTicks(4054) },
                    { new Guid("af69c0ce-a5d9-49b6-9c91-aec6bb73d27f"), new DateTime(2024, 8, 17, 16, 53, 19, 700, DateTimeKind.Local).AddTicks(3991), "Nhận biết, nhắc lại được kiến thức, kĩ năng đã học.", "Nhận biết", new DateTime(2024, 8, 17, 16, 53, 19, 700, DateTimeKind.Local).AddTicks(4005) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DifficultLevels",
                keyColumn: "DifficultLevelId",
                keyValue: new Guid("09593f78-2de4-48dc-9d79-72e72fa33607"));

            migrationBuilder.DeleteData(
                table: "DifficultLevels",
                keyColumn: "DifficultLevelId",
                keyValue: new Guid("47bd5bef-43b8-48a1-8495-b2a09d2f1177"));

            migrationBuilder.DeleteData(
                table: "DifficultLevels",
                keyColumn: "DifficultLevelId",
                keyValue: new Guid("5e0d9a7a-e16d-4e54-be4d-839fa04f5a37"));

            migrationBuilder.DeleteData(
                table: "DifficultLevels",
                keyColumn: "DifficultLevelId",
                keyValue: new Guid("af69c0ce-a5d9-49b6-9c91-aec6bb73d27f"));
        }
    }
}
