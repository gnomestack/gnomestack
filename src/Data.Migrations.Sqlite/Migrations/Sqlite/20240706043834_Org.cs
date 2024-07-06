using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gs.Data.Migrations.Sqlite
{
    /// <inheritdoc />
    public partial class Org : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "organization_id",
                table: "iam_users",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "iam_organizations",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    slug = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_iam_organizations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "iam_organization_domains",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    domain = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    organization_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_iam_organization_domains", x => x.id);
                    table.ForeignKey(
                        name: "fk_iam_organization_domains_iam_organizations_organization_id",
                        column: x => x.organization_id,
                        principalTable: "iam_organizations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "iam_organizations",
                columns: new[] { "id", "name", "slug" },
                values: new object[] { 1, "root", "root" });

            migrationBuilder.CreateIndex(
                name: "ix_iam_users_organization_id",
                table: "iam_users",
                column: "organization_id");

            migrationBuilder.CreateIndex(
                name: "ix_iam_organization_domains_domain",
                table: "iam_organization_domains",
                column: "domain",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_iam_organization_domains_organization_id",
                table: "iam_organization_domains",
                column: "organization_id");

            migrationBuilder.CreateIndex(
                name: "ix_iam_organizations_slug",
                table: "iam_organizations",
                column: "slug",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_iam_users_organizations_organization_id",
                table: "iam_users",
                column: "organization_id",
                principalTable: "iam_organizations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_iam_users_organizations_organization_id",
                table: "iam_users");

            migrationBuilder.DropTable(
                name: "iam_organization_domains");

            migrationBuilder.DropTable(
                name: "iam_organizations");

            migrationBuilder.DropIndex(
                name: "ix_iam_users_organization_id",
                table: "iam_users");

            migrationBuilder.DropColumn(
                name: "organization_id",
                table: "iam_users");
        }
    }
}
