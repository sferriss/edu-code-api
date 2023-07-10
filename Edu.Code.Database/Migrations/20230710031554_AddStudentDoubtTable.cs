using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Edu.Code.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddStudentDoubtTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "student_doubt",
                schema: "edu-code",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    doubt = table.Column<string>(type: "text", nullable: false),
                    code = table.Column<string>(type: "text", nullable: true),
                    answer = table.Column<string>(type: "text", nullable: false),
                    question_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student_doubt", x => x.id);
                    table.ForeignKey(
                        name: "FK_student_doubt_question_question_id",
                        column: x => x.question_id,
                        principalSchema: "edu-code",
                        principalTable: "question",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_student_doubt_question_id",
                schema: "edu-code",
                table: "student_doubt",
                column: "question_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "student_doubt",
                schema: "edu-code");
        }
    }
}
