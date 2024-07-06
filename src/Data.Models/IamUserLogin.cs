using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gs.Data.Models;

public class IamUserLogin : IdentityUserLogin<int>
{
}

public class IamUserLoginConfig : IEntityTypeConfiguration<IamUserLogin>
{
    public IamUserLoginConfig(bool schema = true)
    {
        this.Schema = schema;
    }

    public bool Schema { get; }

    public void Configure(EntityTypeBuilder<IamUserLogin> builder)
    {
        if (this.Schema)
            builder.ToTable("user_logins", "iam");
        else
            builder.ToTable("iam_user_logins");
    }
}