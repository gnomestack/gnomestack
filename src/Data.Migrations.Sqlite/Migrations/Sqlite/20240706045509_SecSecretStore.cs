using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gs.Data.Migrations.Sqlite
{
    /// <inheritdoc />
    public partial class SecSecretStore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sec_secret_stores",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    slug = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sec_secret_stores", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sec_secrets",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    sec_secret_store_id = table.Column<int>(type: "INTEGER", nullable: false),
                    key = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    value = table.Column<string>(type: "TEXT", maxLength: 2048, nullable: false),
                    expires_at = table.Column<DateTime>(type: "TEXT", nullable: true),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sec_secrets", x => x.id);
                    table.ForeignKey(
                        name: "fk_sec_secrets_sec_secret_stores_sec_secret_store_id",
                        column: x => x.sec_secret_store_id,
                        principalTable: "sec_secret_stores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_sec_secret_stores_slug",
                table: "sec_secret_stores",
                column: "slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_sec_secrets_key",
                table: "sec_secrets",
                column: "key",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_sec_secrets_sec_secret_store_id",
                table: "sec_secrets",
                column: "sec_secret_store_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sec_secrets");

            migrationBuilder.DropTable(
                name: "sec_secret_stores");
        }
    }
}
