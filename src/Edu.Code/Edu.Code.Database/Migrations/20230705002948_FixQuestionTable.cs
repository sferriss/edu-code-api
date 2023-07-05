using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Edu.Code.Database.Migrations
{
    /// <inheritdoc />
    public partial class FixQuestionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "answer",
                schema: "edu-code",
                table: "question",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "answer",
                schema: "edu-code",
                table: "question",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
