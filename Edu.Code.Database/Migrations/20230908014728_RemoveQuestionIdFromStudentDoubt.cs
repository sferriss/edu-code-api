using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Edu.Code.Database.Migrations
{
    /// <inheritdoc />
    public partial class RemoveQuestionIdFromStudentDoubt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_student_doubt_question_question_id",
                schema: "edu-code",
                table: "student_doubt");

            migrationBuilder.DropIndex(
                name: "IX_student_doubt_question_id",
                schema: "edu-code",
                table: "student_doubt");

            migrationBuilder.DropColumn(
                name: "question_id",
                schema: "edu-code",
                table: "student_doubt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "question_id",
                schema: "edu-code",
                table: "student_doubt",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_student_doubt_question_id",
                schema: "edu-code",
                table: "student_doubt",
                column: "question_id");

            migrationBuilder.AddForeignKey(
                name: "FK_student_doubt_question_question_id",
                schema: "edu-code",
                table: "student_doubt",
                column: "question_id",
                principalSchema: "edu-code",
                principalTable: "question",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
