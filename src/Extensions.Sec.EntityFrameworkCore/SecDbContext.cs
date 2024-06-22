using System.Diagnostics.CodeAnalysis;

using Microsoft.EntityFrameworkCore;




namespace Gnome.Extensions.Sec;

public class SecDbContext : SecDbContext<ReleaseEnvironment, int>
{
    [RequiresUnreferencedCode("EF Core isn\'t fully compatible with trimming, and running the application may generate unexpected runtime failures. Some specific coding pattern are usually required to make trimming work properly, see https:// aka. ms/ efcore-docs-trimming  for more details.")] 
    [RequiresDynamicCode("EF Core isn\'t fully compatible with NativeAOT, and running the application may generate unexpected runtime failures.")]
    public SecDbContext(DbContextOptions options)
        : base(options)
    {
    }
}

public class SecDbContext<[Dam(DamitCommon.EfEntity)] TReleaseEnvironment, TKey> : DbContext
    where TReleaseEnvironment : ReleaseEnvironment<TKey>
    where TKey : IEquatable<TKey>
{
    [RequiresUnreferencedCode(DamitCommon.DbContextUnreferencedMessage)]
    [RequiresDynamicCode(DamitCommon.RequiresDynamicCodeMessage)]
    public SecDbContext(DbContextOptions options)
        : base(options)
    {
    }

    public DbSet<TReleaseEnvironment> ReleaseEnvironments { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseReleaseEnvironment<TKey>();
    }
}

internal static class DamitCommon
{
    public const Damit EfEntity = Damit.PublicConstructors | Damit.NonPublicConstructors | Damit.NonPublicConstructors | Damit.NonPublicFields | Damit.PublicProperties | Damit.PublicFields | Damit.NonPublicProperties | Damit.Interfaces;

    public const string DbContextUnreferencedMessage = "EF Core isn\'t fully compatible with trimming, and running the application may generate unexpected runtime failures. Some specific coding pattern are usually required to make trimming work properly, see https://aka.ms/efcore-docs-trimming  for more details.";
    
    public const string RequiresDynamicCodeMessage = "EF Core isn\'t fully compatible with NativeAOT, and running the application may generate unexpected runtime failures.";
}