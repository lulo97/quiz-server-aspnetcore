using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class ChangeUniqueKeyToIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "UK_SubSubject_Name",
                table: "SubSubjects");

            migrationBuilder.DropUniqueConstraint(
                name: "UK_Subject_Name",
                table: "Subjects");

            migrationBuilder.DropUniqueConstraint(
                name: "UK_QuestionType_Name",
                table: "QuestionTypes");

            migrationBuilder.DropUniqueConstraint(
                name: "UK_Point_Value",
                table: "Points");

            migrationBuilder.DropUniqueConstraint(
                name: "UK_Language_Name",
                table: "Languages");

            migrationBuilder.DropUniqueConstraint(
                name: "UK_EducationLevel_Name",
                table: "EducationLevels");

            migrationBuilder.DropUniqueConstraint(
                name: "UK_DifficultLevel_Name",
                table: "DifficultLevels");

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

            migrationBuilder.CreateIndex(
                name: "IX_SubSubjects_Name",
                table: "SubSubjects",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_Name",
                table: "Subjects",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuestionTypes_Name",
                table: "QuestionTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Points_Value",
                table: "Points",
                column: "Value",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Languages_Name",
                table: "Languages",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EducationLevels_Name",
                table: "EducationLevels",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DifficultLevels_Name",
                table: "DifficultLevels",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SubSubjects_Name",
                table: "SubSubjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_Name",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_QuestionTypes_Name",
                table: "QuestionTypes");

            migrationBuilder.DropIndex(
                name: "IX_Points_Value",
                table: "Points");

            migrationBuilder.DropIndex(
                name: "IX_Languages_Name",
                table: "Languages");

            migrationBuilder.DropIndex(
                name: "IX_EducationLevels_Name",
                table: "EducationLevels");

            migrationBuilder.DropIndex(
                name: "IX_DifficultLevels_Name",
                table: "DifficultLevels");

            migrationBuilder.AddUniqueConstraint(
                name: "UK_SubSubject_Name",
                table: "SubSubjects",
                column: "Name");

            migrationBuilder.AddUniqueConstraint(
                name: "UK_Subject_Name",
                table: "Subjects",
                column: "Name");

            migrationBuilder.AddUniqueConstraint(
                name: "UK_QuestionType_Name",
                table: "QuestionTypes",
                column: "Name");

            migrationBuilder.AddUniqueConstraint(
                name: "UK_Point_Value",
                table: "Points",
                column: "Value");

            migrationBuilder.AddUniqueConstraint(
                name: "UK_Language_Name",
                table: "Languages",
                column: "Name");

            migrationBuilder.AddUniqueConstraint(
                name: "UK_EducationLevel_Name",
                table: "EducationLevels",
                column: "Name");

            migrationBuilder.AddUniqueConstraint(
                name: "UK_DifficultLevel_Name",
                table: "DifficultLevels",
                column: "Name");

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
    }
}
