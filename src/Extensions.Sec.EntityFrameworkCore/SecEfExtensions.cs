using System.Reflection.Emit;

using Microsoft.EntityFrameworkCore;

namespace Gnome.Extensions.Sec;

public static class SecEfExtensions
{
    public static ModelBuilder UseReleaseEnvironment<TKey>(this ModelBuilder builder)
        where TKey : IEquatable<TKey>
    {
        builder.ApplyConfiguration(new ReleaseEnvironmentConfig<TKey>());
        return builder;
    }

    public static ModelBuilder UseReleaseEnvironment(this ModelBuilder builder)
    {
        builder.ApplyConfiguration(new ReleaseEnvironmentConfig<int>());
        return builder;
    }
}