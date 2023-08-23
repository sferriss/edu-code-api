using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Edu.Code.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddModuleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "module",
                schema: "edu-code",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_module", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "module_content",
                schema: "edu-code",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    module_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_module_content", x => x.id);
                    table.ForeignKey(
                        name: "FK_module_content_module_module_id",
                        column: x => x.module_id,
                        principalSchema: "edu-code",
                        principalTable: "module",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_module_content_module_id",
                schema: "edu-code",
                table: "module_content",
                column: "module_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "module_content",
                schema: "edu-code");

            migrationBuilder.DropTable(
                name: "module",
                schema: "edu-code");
        }
    }
}
