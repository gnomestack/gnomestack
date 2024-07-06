using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gs.Data.Models;

public class IamRoleClaim : IdentityRoleClaim<int>
{
}

public class IamRoleClaimConfig : IEntityTypeConfiguration<IamRoleClaim>
{
    public IamRoleClaimConfig(bool schema = true)
    {
        this.Schema = schema;
    }

    public bool Schema { get; }

    public virtual void Configure(EntityTypeBuilder<IamRoleClaim> builder)
    {
        if (this.Schema)
            builder.ToTable("role_claims", "iam");
        else
            builder.ToTable("iam_role_claims");
    }
}