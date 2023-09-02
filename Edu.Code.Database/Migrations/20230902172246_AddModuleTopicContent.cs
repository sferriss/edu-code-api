using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Edu.Code.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddModuleTopicContent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "module_content",
                schema: "edu-code");

            migrationBuilder.CreateTable(
                name: "module_topic",
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
                    table.PrimaryKey("PK_module_topic", x => x.id);
                    table.ForeignKey(
                        name: "FK_module_topic_module_module_id",
                        column: x => x.module_id,
                        principalSchema: "edu-code",
                        principalTable: "module",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "topic_content",
                schema: "edu-code",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    topic_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_topic_content", x => x.id);
                    table.ForeignKey(
                        name: "FK_topic_content_module_topic_topic_id",
                        column: x => x.topic_id,
                        principalSchema: "edu-code",
                        principalTable: "module_topic",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_module_topic_module_id",
                schema: "edu-code",
                table: "module_topic",
                column: "module_id");

            migrationBuilder.CreateIndex(
                name: "IX_topic_content_topic_id",
                schema: "edu-code",
                table: "topic_content",
                column: "topic_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "topic_content",
                schema: "edu-code");

            migrationBuilder.DropTable(
                name: "module_topic",
                schema: "edu-code");

            migrationBuilder.CreateTable(
                name: "module_content",
                schema: "edu-code",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    module_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    title = table.Column<string>(type: "text", nullable: true)
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
    }
}
