using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Gs.Data.Models;

public class GsDbContext : IdentityDbContext<IamUser, IamRole, int, IamUserClaim, IamUserRole, IamUserLogin, IamRoleClaim, IamUserToken>
{
    public GsDbContext(DbContextOptions options)
        : base(options)
    {
    }

    public DbSet<IamOrganization> Organizations { get; set; } = null!;

    public DbSet<IamOrganizationDomain> OrganizationDomains { get; set; } = null!;

    public DbSet<SecSecretVault> SecretVaults { get; set; } = null!;

    public DbSet<SecSecret> Secrets { get; set; } = null!;

    protected bool UseSchema { get; set; } = true;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSnakeCaseNamingConvention();
        }

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // Call the base method to configure the default behavior
        // and ensure the config classes override the default behavior
        // by calling them after the base method.
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new IamUserConfig(this.UseSchema));
        builder.ApplyConfiguration(new IamRoleConfig(this.UseSchema));
        builder.ApplyConfiguration(new IamUserClaimConfig(this.UseSchema));
        builder.ApplyConfiguration(new IamUserRoleConfig(this.UseSchema));
        builder.ApplyConfiguration(new IamUserLoginConfig(this.UseSchema));
        builder.ApplyConfiguration(new IamRoleClaimConfig(this.UseSchema));
        builder.ApplyConfiguration(new IamUserTokenConfig(this.UseSchema));
        builder.ApplyConfiguration(new IamOrganizationConfig(this.UseSchema));
        builder.ApplyConfiguration(new IamOrganizationDomainConfig(this.UseSchema));
        builder.ApplyConfiguration(new SecSecretVaultConfig(this.UseSchema));
        builder.ApplyConfiguration(new SecSecretConfig(this.UseSchema));
    }
}