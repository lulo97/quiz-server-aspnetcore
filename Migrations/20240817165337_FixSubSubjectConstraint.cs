using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class FixSubSubjectConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SubSubjects_Name",
                table: "SubSubjects");

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
                name: "IX_SubSubjects_Name_SubjectId_EducationLevelId",
                table: "SubSubjects",
                columns: new[] { "Name", "SubjectId", "EducationLevelId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SubSubjects_Name_SubjectId_EducationLevelId",
                table: "SubSubjects");

            migrationBuilder.UpdateData(
                table: "DifficultLevels",
                keyColumn: "DifficultLevelId",
                keyValue: new Guid("09593f78-2de4-48dc-9d79-72e72fa33607"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 17, 19, 56, 9, 8, DateTimeKind.Local).AddTicks(3897), new DateTime(2024, 8, 17, 19, 56, 9, 8, DateTimeKind.Local).AddTicks(3898) });

            migrationBuilder.UpdateData(
                table: "DifficultLevels",
                keyColumn: "DifficultLevelId",
                keyValue: new Guid("47bd5bef-43b8-48a1-8495-b2a09d2f1177"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 17, 19, 56, 9, 8, DateTimeKind.Local).AddTicks(3912), new DateTime(2024, 8, 17, 19, 56, 9, 8, DateTimeKind.Local).AddTicks(3913) });

            migrationBuilder.UpdateData(
                table: "DifficultLevels",
                keyColumn: "DifficultLevelId",
                keyValue: new Guid("5e0d9a7a-e16d-4e54-be4d-839fa04f5a37"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 17, 19, 56, 9, 8, DateTimeKind.Local).AddTicks(3884), new DateTime(2024, 8, 17, 19, 56, 9, 8, DateTimeKind.Local).AddTicks(3884) });

            migrationBuilder.UpdateData(
                table: "DifficultLevels",
                keyColumn: "DifficultLevelId",
                keyValue: new Guid("af69c0ce-a5d9-49b6-9c91-aec6bb73d27f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 17, 19, 56, 9, 8, DateTimeKind.Local).AddTicks(3824), new DateTime(2024, 8, 17, 19, 56, 9, 8, DateTimeKind.Local).AddTicks(3837) });

            migrationBuilder.CreateIndex(
                name: "IX_SubSubjects_Name",
                table: "SubSubjects",
                column: "Name",
                unique: true);
        }
    }
}
