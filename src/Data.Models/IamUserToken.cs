using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gs.Data.Models;

public class IamUserToken : IdentityUserToken<int>
{
}

public class IamUserTokenConfig : IEntityTypeConfiguration<IamUserToken>
{
    public IamUserTokenConfig(bool schema = true)
    {
        this.Schema = schema;
    }

    public bool Schema { get; }

    public void Configure(EntityTypeBuilder<IamUserToken> builder)
    {
        if (this.Schema)
            builder.ToTable("user_tokens", "iam");
        else
            builder.ToTable("iam_user_tokens");
    }
}