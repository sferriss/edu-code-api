using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Edu.Code.Database.Migrations
{
    /// <inheritdoc />
    public partial class DoubtTypeColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "type",
                schema: "edu-code",
                table: "student_doubt",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "type",
                schema: "edu-code",
                table: "student_doubt");
        }
    }
}
