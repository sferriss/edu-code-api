using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Edu.Code.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddQuestionExampleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "answer",
                schema: "edu-code",
                table: "question");

            migrationBuilder.DropColumn(
                name: "example",
                schema: "edu-code",
                table: "question");

            migrationBuilder.AddColumn<string>(
                name: "title",
                schema: "edu-code",
                table: "question",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "question_example",
                schema: "edu-code",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    input = table.Column<string>(type: "text", nullable: false),
                    output = table.Column<string>(type: "text", nullable: false),
                    question_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_question_example", x => x.id);
                    table.ForeignKey(
                        name: "FK_question_example_question_question_id",
                        column: x => x.question_id,
                        principalSchema: "edu-code",
                        principalTable: "question",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_question_example_question_id",
                schema: "edu-code",
                table: "question_example",
                column: "question_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "question_example",
                schema: "edu-code");

            migrationBuilder.DropColumn(
                name: "title",
                schema: "edu-code",
                table: "question");

            migrationBuilder.AddColumn<string>(
                name: "answer",
                schema: "edu-code",
                table: "question",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "example",
                schema: "edu-code",
                table: "question",
                type: "text",
                nullable: true);
        }
    }
}
