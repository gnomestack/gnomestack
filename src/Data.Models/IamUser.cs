using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage;

namespace Gs.Data.Models;

public class IamUser : IdentityUser<int>
{
    public int OrganizationId { get; set; } = 1;

    public IamOrganization Organization { get; set; } = null!;
}

public class IamUserConfig : IEntityTypeConfiguration<IamUser>
{
    public IamUserConfig(bool schema = true)
    {
        this.Schema = schema;
    }

    public bool Schema { get; }

    public virtual void Configure(EntityTypeBuilder<IamUser> builder)
    {
        if (this.Schema)
        {
            builder.ToTable("users", "iam");
            builder.HasIndex(o => o.NormalizedEmail)
                .HasDatabaseName("ix_users_normalized_email");

            builder.HasIndex(o => o.NormalizedUserName)
                .IsUnique()
                .HasDatabaseName("ix_users_normalized_user_name");
        }
        else
        {
            builder.ToTable("iam_users");
            builder.HasIndex(o => o.NormalizedEmail)
                .HasDatabaseName("ix_iam_users_normalized_email");

            builder.HasIndex(o => o.NormalizedUserName)
                .IsUnique()
                .HasDatabaseName("ix_iam_users_normalized_user_name");
        }
    }
}