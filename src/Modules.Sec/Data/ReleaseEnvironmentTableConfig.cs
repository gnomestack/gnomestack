using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gs.Modules.Sec.Data;

public class ReleaseEnvironmentTableConfig<TId> : IEntityTypeConfiguration<ReleaseEnvironmentTable<TId>>
    where TId : IEquatable<TId>
{
    public void Configure(EntityTypeBuilder<ReleaseEnvironmentTable<TId>> builder)
    {
        builder.Property(o => o.Key).HasMaxLength(64).IsRequired();

        builder.ToTable("release_environments");
    }
}