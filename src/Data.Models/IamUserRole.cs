using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gs.Data.Models;

public class IamUserRole : IdentityUserRole<int>
{
}

public class IamUserRoleConfig : IEntityTypeConfiguration<IamUserRole>
{
    public IamUserRoleConfig(bool schema = true)
    {
        this.Schema = schema;
    }

    public bool Schema { get; }

    public void Configure(EntityTypeBuilder<IamUserRole> builder)
    {
        if (this.Schema)
            builder.ToTable("users_roles", "iam");
        else
            builder.ToTable("iam_users_roles");
        
        
    }
}