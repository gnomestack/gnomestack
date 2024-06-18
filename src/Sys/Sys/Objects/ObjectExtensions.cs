namespace Gnome.Sys.Objects;

public static class ObjectExtensions
{
    public static string ToSafeString(this object? obj)
        => obj?.ToString() ?? string.Empty;
}