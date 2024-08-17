using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddFKForSubSubject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "IX_SubSubjects_EducationLevelId",
                table: "SubSubjects",
                column: "EducationLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_SubSubjects_SubjectId",
                table: "SubSubjects",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubSubjects_EducationLevels_EducationLevelId",
                table: "SubSubjects",
                column: "EducationLevelId",
                principalTable: "EducationLevels",
                principalColumn: "EducationLevelId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubSubjects_Subjects_SubjectId",
                table: "SubSubjects",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubSubjects_EducationLevels_EducationLevelId",
                table: "SubSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_SubSubjects_Subjects_SubjectId",
                table: "SubSubjects");

            migrationBuilder.DropIndex(
                name: "IX_SubSubjects_EducationLevelId",
                table: "SubSubjects");

            migrationBuilder.DropIndex(
                name: "IX_SubSubjects_SubjectId",
                table: "SubSubjects");

            migrationBuilder.UpdateData(
                table: "DifficultLevels",
                keyColumn: "DifficultLevelId",
                keyValue: new Guid("09593f78-2de4-48dc-9d79-72e72fa33607"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 17, 17, 45, 16, 446, DateTimeKind.Local).AddTicks(2652), new DateTime(2024, 8, 17, 17, 45, 16, 446, DateTimeKind.Local).AddTicks(2652) });

            migrationBuilder.UpdateData(
                table: "DifficultLevels",
                keyColumn: "DifficultLevelId",
                keyValue: new Guid("47bd5bef-43b8-48a1-8495-b2a09d2f1177"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 17, 17, 45, 16, 446, DateTimeKind.Local).AddTicks(2667), new DateTime(2024, 8, 17, 17, 45, 16, 446, DateTimeKind.Local).AddTicks(2667) });

            migrationBuilder.UpdateData(
                table: "DifficultLevels",
                keyColumn: "DifficultLevelId",
                keyValue: new Guid("5e0d9a7a-e16d-4e54-be4d-839fa04f5a37"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 17, 17, 45, 16, 446, DateTimeKind.Local).AddTicks(2634), new DateTime(2024, 8, 17, 17, 45, 16, 446, DateTimeKind.Local).AddTicks(2634) });

            migrationBuilder.UpdateData(
                table: "DifficultLevels",
                keyColumn: "DifficultLevelId",
                keyValue: new Guid("af69c0ce-a5d9-49b6-9c91-aec6bb73d27f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 17, 17, 45, 16, 446, DateTimeKind.Local).AddTicks(2567), new DateTime(2024, 8, 17, 17, 45, 16, 446, DateTimeKind.Local).AddTicks(2584) });
        }
    }
}
