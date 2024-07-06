using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Gs.Data.Migrations.Pgsql
{
    /// <inheritdoc />
    public partial class SecSecretStore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "sec");

            migrationBuilder.CreateTable(
                name: "secret_stores",
                schema: "sec",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    slug = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_secret_stores", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "secrets",
                schema: "sec",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    sec_secret_store_id = table.Column<int>(type: "integer", nullable: false),
                    key = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    value = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: false),
                    expires_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_secrets", x => x.id);
                    table.ForeignKey(
                        name: "fk_secrets_secret_stores_sec_secret_store_id",
                        column: x => x.sec_secret_store_id,
                        principalSchema: "sec",
                        principalTable: "secret_stores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_secret_stores_slug",
                schema: "sec",
                table: "secret_stores",
                column: "slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_secrets_key",
                schema: "sec",
                table: "secrets",
                column: "key",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_secrets_sec_secret_store_id",
                schema: "sec",
                table: "secrets",
                column: "sec_secret_store_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "secrets",
                schema: "sec");

            migrationBuilder.DropTable(
                name: "secret_stores",
                schema: "sec");
        }
    }
}
