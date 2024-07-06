using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gs.Data.Migrations.Sqlite
{
    /// <inheritdoc />
    public partial class iam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "iam_roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    normalized_name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    concurrency_stamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_iam_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "iam_users",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    user_name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    normalized_user_name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    normalized_email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    email_confirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    password_hash = table.Column<string>(type: "TEXT", nullable: true),
                    security_stamp = table.Column<string>(type: "TEXT", nullable: true),
                    concurrency_stamp = table.Column<string>(type: "TEXT", nullable: true),
                    phone_number = table.Column<string>(type: "TEXT", nullable: true),
                    phone_number_confirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    two_factor_enabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    lockout_end = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    lockout_enabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    access_failed_count = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_iam_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "iam_role_claims",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    role_id = table.Column<int>(type: "INTEGER", nullable: false),
                    claim_type = table.Column<string>(type: "TEXT", nullable: true),
                    claim_value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_iam_role_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_iam_role_claims_iam_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "iam_roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "iam_user_claims",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    user_id = table.Column<int>(type: "INTEGER", nullable: false),
                    claim_type = table.Column<string>(type: "TEXT", nullable: true),
                    claim_value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_iam_user_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_iam_user_claims_iam_users_user_id",
                        column: x => x.user_id,
                        principalTable: "iam_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "iam_user_logins",
                columns: table => new
                {
                    login_provider = table.Column<string>(type: "TEXT", nullable: false),
                    provider_key = table.Column<string>(type: "TEXT", nullable: false),
                    provider_display_name = table.Column<string>(type: "TEXT", nullable: true),
                    user_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_iam_user_logins", x => new { x.login_provider, x.provider_key });
                    table.ForeignKey(
                        name: "fk_iam_user_logins_iam_users_user_id",
                        column: x => x.user_id,
                        principalTable: "iam_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "iam_user_tokens",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "INTEGER", nullable: false),
                    login_provider = table.Column<string>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_iam_user_tokens", x => new { x.user_id, x.login_provider, x.name });
                    table.ForeignKey(
                        name: "fk_iam_user_tokens_iam_users_user_id",
                        column: x => x.user_id,
                        principalTable: "iam_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "iam_users_roles",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "INTEGER", nullable: false),
                    role_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_iam_users_roles", x => new { x.user_id, x.role_id });
                    table.ForeignKey(
                        name: "fk_iam_users_roles_iam_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "iam_roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_iam_users_roles_iam_users_user_id",
                        column: x => x.user_id,
                        principalTable: "iam_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_iam_role_claims_role_id",
                table: "iam_role_claims",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "ix_iam_roles_normalized_name",
                table: "iam_roles",
                column: "normalized_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_iam_user_claims_user_id",
                table: "iam_user_claims",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_iam_user_logins_user_id",
                table: "iam_user_logins",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_iam_users_normalized_email",
                table: "iam_users",
                column: "normalized_email");

            migrationBuilder.CreateIndex(
                name: "ix_iam_users_normalized_user_name",
                table: "iam_users",
                column: "normalized_user_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_iam_users_roles_role_id",
                table: "iam_users_roles",
                column: "role_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "iam_role_claims");

            migrationBuilder.DropTable(
                name: "iam_user_claims");

            migrationBuilder.DropTable(
                name: "iam_user_logins");

            migrationBuilder.DropTable(
                name: "iam_user_tokens");

            migrationBuilder.DropTable(
                name: "iam_users_roles");

            migrationBuilder.DropTable(
                name: "iam_roles");

            migrationBuilder.DropTable(
                name: "iam_users");
        }
    }
}
