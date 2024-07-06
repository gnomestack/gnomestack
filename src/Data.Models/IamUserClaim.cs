using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gs.Data.Models;

public class IamUserClaim : IdentityUserClaim<int>
{
}

public class IamUserClaimConfig : IEntityTypeConfiguration<IamUserClaim>
{
    public IamUserClaimConfig(bool schema = true)
    {
        this.Schema = schema;
    }

    public bool Schema { get; }

    public void Configure(EntityTypeBuilder<IamUserClaim> builder)
    {
        if (this.Schema)
            builder.ToTable("user_claims", "iam");
        else
            builder.ToTable("iam_user_claims");
    }
}