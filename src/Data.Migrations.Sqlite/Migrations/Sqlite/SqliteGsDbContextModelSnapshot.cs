﻿// <auto-generated />
using System;
using Gs.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Gs.Data.Migrations.Sqlite
{
    [DbContext(typeof(SqliteGsDbContext))]
    partial class SqliteGsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("Gs.Data.Models.IamOrganization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("TEXT")
                        .HasColumnName("slug");

                    b.HasKey("Id")
                        .HasName("pk_iam_organizations");

                    b.HasIndex("Slug")
                        .IsUnique()
                        .HasDatabaseName("ix_iam_organizations_slug");

                    b.ToTable("iam_organizations", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "root",
                            Slug = "root"
                        });
                });

            modelBuilder.Entity("Gs.Data.Models.IamOrganizationDomain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("Domain")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("TEXT")
                        .HasColumnName("domain");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("organization_id");

                    b.HasKey("Id")
                        .HasName("pk_iam_organization_domains");

                    b.HasIndex("Domain")
                        .IsUnique()
                        .HasDatabaseName("ix_iam_organization_domains_domain");

                    b.HasIndex("OrganizationId")
                        .HasDatabaseName("ix_iam_organization_domains_organization_id");

                    b.ToTable("iam_organization_domains", (string)null);
                });

            modelBuilder.Entity("Gs.Data.Models.IamRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT")
                        .HasColumnName("concurrency_stamp");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT")
                        .HasColumnName("normalized_name");

                    b.HasKey("Id")
                        .HasName("pk_iam_roles");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("ix_iam_roles_normalized_name");

                    b.ToTable("iam_roles", (string)null);
                });

            modelBuilder.Entity("Gs.Data.Models.IamRoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT")
                        .HasColumnName("claim_type");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT")
                        .HasColumnName("claim_value");

                    b.Property<int>("RoleId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("role_id");

                    b.HasKey("Id")
                        .HasName("pk_iam_role_claims");

                    b.HasIndex("RoleId")
                        .HasDatabaseName("ix_iam_role_claims_role_id");

                    b.ToTable("iam_role_claims", (string)null);
                });

            modelBuilder.Entity("Gs.Data.Models.IamUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER")
                        .HasColumnName("access_failed_count");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT")
                        .HasColumnName("concurrency_stamp");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT")
                        .HasColumnName("email");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER")
                        .HasColumnName("email_confirmed");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER")
                        .HasColumnName("lockout_enabled");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT")
                        .HasColumnName("lockout_end");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT")
                        .HasColumnName("normalized_email");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT")
                        .HasColumnName("normalized_user_name");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("organization_id");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT")
                        .HasColumnName("password_hash");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT")
                        .HasColumnName("phone_number");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER")
                        .HasColumnName("phone_number_confirmed");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT")
                        .HasColumnName("security_stamp");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER")
                        .HasColumnName("two_factor_enabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT")
                        .HasColumnName("user_name");

                    b.HasKey("Id")
                        .HasName("pk_iam_users");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("ix_iam_users_normalized_email");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("ix_iam_users_normalized_user_name");

                    b.HasIndex("OrganizationId")
                        .HasDatabaseName("ix_iam_users_organization_id");

                    b.ToTable("iam_users", (string)null);
                });

            modelBuilder.Entity("Gs.Data.Models.IamUserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT")
                        .HasColumnName("claim_type");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT")
                        .HasColumnName("claim_value");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_iam_user_claims");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_iam_user_claims_user_id");

                    b.ToTable("iam_user_claims", (string)null);
                });

            modelBuilder.Entity("Gs.Data.Models.IamUserLogin", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT")
                        .HasColumnName("login_provider");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT")
                        .HasColumnName("provider_key");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT")
                        .HasColumnName("provider_display_name");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("user_id");

                    b.HasKey("LoginProvider", "ProviderKey")
                        .HasName("pk_iam_user_logins");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_iam_user_logins_user_id");

                    b.ToTable("iam_user_logins", (string)null);
                });

            modelBuilder.Entity("Gs.Data.Models.IamUserRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("user_id");

                    b.Property<int>("RoleId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("role_id");

                    b.HasKey("UserId", "RoleId")
                        .HasName("pk_iam_users_roles");

                    b.HasIndex("RoleId")
                        .HasDatabaseName("ix_iam_users_roles_role_id");

                    b.ToTable("iam_users_roles", (string)null);
                });

            modelBuilder.Entity("Gs.Data.Models.IamUserToken", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("user_id");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT")
                        .HasColumnName("login_provider");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT")
                        .HasColumnName("value");

                    b.HasKey("UserId", "LoginProvider", "Name")
                        .HasName("pk_iam_user_tokens");

                    b.ToTable("iam_user_tokens", (string)null);
                });

            modelBuilder.Entity("Gs.Data.Models.SecSecret", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("ExpiresAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("expires_at");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("TEXT")
                        .HasColumnName("key");

                    b.Property<int>("SecSecretStoreId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("sec_secret_store_id");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("TEXT")
                        .HasColumnName("value");

                    b.HasKey("Id")
                        .HasName("pk_sec_secrets");

                    b.HasIndex("Key")
                        .IsUnique()
                        .HasDatabaseName("ix_sec_secrets_key");

                    b.HasIndex("SecSecretStoreId")
                        .HasDatabaseName("ix_sec_secrets_sec_secret_store_id");

                    b.ToTable("sec_secrets", (string)null);
                });

            modelBuilder.Entity("Gs.Data.Models.SecSecretVault", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("TEXT")
                        .HasColumnName("slug");

                    b.HasKey("Id")
                        .HasName("pk_sec_secret_stores");

                    b.HasIndex("Slug")
                        .IsUnique()
                        .HasDatabaseName("ix_sec_secret_stores_slug");

                    b.ToTable("sec_secret_stores", (string)null);
                });

            modelBuilder.Entity("Gs.Data.Models.IamOrganizationDomain", b =>
                {
                    b.HasOne("Gs.Data.Models.IamOrganization", "Organization")
                        .WithMany("Domains")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_iam_organization_domains_iam_organizations_organization_id");

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("Gs.Data.Models.IamRoleClaim", b =>
                {
                    b.HasOne("Gs.Data.Models.IamRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_iam_role_claims_iam_roles_role_id");
                });

            modelBuilder.Entity("Gs.Data.Models.IamUser", b =>
                {
                    b.HasOne("Gs.Data.Models.IamOrganization", "Organization")
                        .WithMany("Users")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_iam_users_organizations_organization_id");

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("Gs.Data.Models.IamUserClaim", b =>
                {
                    b.HasOne("Gs.Data.Models.IamUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_iam_user_claims_iam_users_user_id");
                });

            modelBuilder.Entity("Gs.Data.Models.IamUserLogin", b =>
                {
                    b.HasOne("Gs.Data.Models.IamUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_iam_user_logins_iam_users_user_id");
                });

            modelBuilder.Entity("Gs.Data.Models.IamUserRole", b =>
                {
                    b.HasOne("Gs.Data.Models.IamRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_iam_users_roles_iam_roles_role_id");

                    b.HasOne("Gs.Data.Models.IamUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_iam_users_roles_iam_users_user_id");
                });

            modelBuilder.Entity("Gs.Data.Models.IamUserToken", b =>
                {
                    b.HasOne("Gs.Data.Models.IamUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_iam_user_tokens_iam_users_user_id");
                });

            modelBuilder.Entity("Gs.Data.Models.SecSecret", b =>
                {
                    b.HasOne("Gs.Data.Models.SecSecretVault", "SecSecretVault")
                        .WithMany("Secrets")
                        .HasForeignKey("SecSecretStoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_sec_secrets_sec_secret_stores_sec_secret_store_id");

                    b.Navigation("SecSecretVault");
                });

            modelBuilder.Entity("Gs.Data.Models.IamOrganization", b =>
                {
                    b.Navigation("Domains");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Gs.Data.Models.SecSecretVault", b =>
                {
                    b.Navigation("Secrets");
                });
#pragma warning restore 612, 618
        }
    }
}
