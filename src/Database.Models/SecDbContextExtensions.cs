using System.Reflection.Emit;

using Microsoft.EntityFrameworkCore;

namespace Gs.Database.Models;

public static class SecDbContextExtensions
{
    public static ModelBuilder UseReleaseEnvironment(this ModelBuilder builder)
    {
        var model = builder.Entity<ReleaseEnvironment>();
        model.Property(o => o.Key).HasMaxLength(64);
        model.ToTable("release_environments");
        model.HasKey(o => o.Id);
        return builder;
    }
}