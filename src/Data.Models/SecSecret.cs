using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gs.Data.Models;

public class SecSecret
{
    public int Id { get; set; }

    public int SecSecretStoreId { get; set; }

    public SecSecretVault SecSecretVault { get; set; } = null!;

    public string Key { get; set; } = string.Empty;

    public string Value { get; set; } = string.Empty;

    public DateTime? ExpiresAt { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

public class SecSecretConfig : IEntityTypeConfiguration<SecSecret>
{
    public SecSecretConfig(bool schema = true)
    {
        this.Schema = schema;
    }

    public bool Schema { get; }

    public virtual void Configure(EntityTypeBuilder<SecSecret> builder)
    {
        builder.Property(o => o.Key)
            .HasMaxLength(256)
            .IsRequired();

        builder.Property(o => o.Value)
            .HasMaxLength(2048)
            .IsRequired();

        builder.HasOne(o => o.SecSecretVault)
            .WithMany(o => o.Secrets)
            .HasForeignKey(o => o.SecSecretStoreId)
            .IsRequired();

        if (this.Schema)
        {
            builder.ToTable("secrets", "sec");
            builder.HasIndex(o => o.Key)
                .IsUnique()
                .HasDatabaseName("ix_secrets_key");
        }
        else
        {
            builder.ToTable("sec_secrets");
            builder.HasIndex(o => o.Key)
                .IsUnique()
                .HasDatabaseName("ix_sec_secrets_key");
        }
    }
}