using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gnome.Extensions.Sec;

public class ReleaseEnvironmentConfig<TKey> : IEntityTypeConfiguration<ReleaseEnvironment<TKey>>
    where TKey : IEquatable<TKey>
{
    public virtual void Configure(EntityTypeBuilder<ReleaseEnvironment<TKey>> builder)
    {
        builder.Property(o => o.Key).HasMaxLength(64);
        builder.ToTable("release_environments");
    }
}