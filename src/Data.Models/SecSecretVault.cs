using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gs.Data.Models;

public class SecSecretVault
{
    public int Id { get; set; }

    public string Slug { get; set; } = string.Empty;

    public HashSet<SecSecret> Secrets { get; set; } = new();
}

public class SecSecretVaultConfig : IEntityTypeConfiguration<SecSecretVault>
{
    public SecSecretVaultConfig(bool schema = true)
    {
        this.Schema = schema;
    }

    public bool Schema { get; }

    public virtual void Configure(EntityTypeBuilder<SecSecretVault> builder)
    {
        builder.Property(o => o.Slug)
            .HasMaxLength(256)
            .IsRequired();

        if (this.Schema)
        {
            builder.ToTable("secret_stores", "sec");
            builder.HasIndex(o => o.Slug)
                .IsUnique()
                .HasDatabaseName("ix_secret_stores_slug");
        }
        else
        {
            builder.ToTable("sec_secret_stores");
            builder.HasIndex(o => o.Slug)
                .IsUnique()
                .HasDatabaseName("ix_sec_secret_stores_slug");
        }
    }
}