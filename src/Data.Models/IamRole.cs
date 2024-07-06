using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gs.Data.Models;

public class IamRole : IdentityRole<int>
{
}

public class IamRoleConfig : IEntityTypeConfiguration<IamRole>
{
    public IamRoleConfig(bool schema = true)
    {
        this.Schema = schema;
    }

    public bool Schema { get; }

    public virtual void Configure(EntityTypeBuilder<IamRole> builder)
    {
        if (this.Schema)
        {
            builder.ToTable("roles", "iam");
            builder.HasIndex(o => o.NormalizedName)
                .IsUnique()
                .HasDatabaseName("ix_roles_normalized_name");
        }
        else
        {
            builder.ToTable("iam_roles");
            builder.HasIndex(o => o.NormalizedName)
                .IsUnique()
                .HasDatabaseName("ix_iam_roles_normalized_name");
        }
    }
}