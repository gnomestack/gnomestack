using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Gs.Data.Migrations.Pgsql
{
    /// <inheritdoc />
    public partial class Org : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "organization_id",
                schema: "iam",
                table: "users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "organizations",
                schema: "iam",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    slug = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_organizations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "organization_domains",
                schema: "iam",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    domain = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    organization_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_organization_domains", x => x.id);
                    table.ForeignKey(
                        name: "fk_organization_domains_organizations_organization_id",
                        column: x => x.organization_id,
                        principalSchema: "iam",
                        principalTable: "organizations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "iam",
                table: "organizations",
                columns: new[] { "id", "name", "slug" },
                values: new object[] { 1, "root", "root" });

            migrationBuilder.CreateIndex(
                name: "ix_users_organization_id",
                schema: "iam",
                table: "users",
                column: "organization_id");

            migrationBuilder.CreateIndex(
                name: "ix_organization_domains_domain",
                schema: "iam",
                table: "organization_domains",
                column: "domain",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_organization_domains_organization_id",
                schema: "iam",
                table: "organization_domains",
                column: "organization_id");

            migrationBuilder.CreateIndex(
                name: "ix_organizations_slug",
                schema: "iam",
                table: "organizations",
                column: "slug",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_users_organizations_organization_id",
                schema: "iam",
                table: "users",
                column: "organization_id",
                principalSchema: "iam",
                principalTable: "organizations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_users_organizations_organization_id",
                schema: "iam",
                table: "users");

            migrationBuilder.DropTable(
                name: "organization_domains",
                schema: "iam");

            migrationBuilder.DropTable(
                name: "organizations",
                schema: "iam");

            migrationBuilder.DropIndex(
                name: "ix_users_organization_id",
                schema: "iam",
                table: "users");

            migrationBuilder.DropColumn(
                name: "organization_id",
                schema: "iam",
                table: "users");
        }
    }
}
