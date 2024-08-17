using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class CreateQuestionTablesModify : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "NameIsUnique",
                table: "DifficultLevels");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SubSubjects",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Subjects",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "QuestionTypes",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Languages",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "EducationLevels",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

            migrationBuilder.AddCheckConstraint(
                name: "CC_Point_Value",
                table: "Points",
                sql: "[Value] > 0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropCheckConstraint(
                name: "CC_Point_Value",
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

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SubSubjects",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Subjects",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "QuestionTypes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Languages",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "EducationLevels",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddUniqueConstraint(
                name: "NameIsUnique",
                table: "DifficultLevels",
                column: "Name");
        }
    }
}
