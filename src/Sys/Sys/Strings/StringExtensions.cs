using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Text;

using Gnome.Text;

namespace Gnome.Sys.Strings;

#if GNOME_EXPOSE
public
#else
internal
#endif
static class StringExtensions
{
    /// <summary>
    /// Indicates whether or not the <see cref="string"/> value is null, empty, or white space.
    /// </summary>
    /// <param name="source">The source string.</param>
    /// <returns><see langword="true" /> if the <see cref="string"/>
    /// is null, empty, or white space; otherwise, <see langword="false" />.
    /// </returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNullOrWhiteSpace([NotNullWhen(false)] this string? source)
        => string.IsNullOrWhiteSpace(source);

    /// <summary>
    /// Indicates whether or not the <see cref="string"/> value is null or empty.
    /// </summary>
    /// <param name="source">The <see cref="string"/> value.</param>
    /// <returns><see langword="true" /> if the <see cref="string"/> is null or empty; otherwise, <see langword="false" />.</returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNullOrEmpty([NotNullWhen(false)] this string? source)
        => string.IsNullOrEmpty(source);

#if NETLEGACY
    /// <summary>
    /// Splits a <see cref="string"/> into substrings using the separator.
    /// </summary>
    /// <param name="source">The string instance to split.</param>
    /// <param name="separator">The separator that is used to split the string.</param>
    /// <returns>The <see cref="T:string[]"/>.</returns>
    public static string[] Split(this string source, string separator)
    {
        return source.Split(separator.ToCharArray());
    }

    /// <summary>
    /// Splits a <see cref="string"/> into substrings using the separator.
    /// </summary>
    /// <param name="source">The string instance to split.</param>
    /// <param name="separator">The separator that is used to split the string.</param>
    /// <param name="options">The string split options.</param>
    /// <returns>The <see cref="T:string[]"/>.</returns>
    public static string[] Split(this string source, char separator, StringSplitOptions options)
    {
        return source.Split(new[] { separator }, options);
    }

    /// <summary>
    /// Splits a <see cref="string"/> into substrings using the separator.
    /// </summary>
    /// <param name="source">The string instance to split.</param>
    /// <param name="separator">The separator that is used to split the string.</param>
    /// <param name="options">The string split options.</param>
    /// <returns>The <see cref="T:string[]"/>.</returns>
    public static string[] Split(this string source, string separator, StringSplitOptions options)
    {
        return source.Split(separator.ToCharArray(), options);
    }
#endif

    /// <summary>
    /// Converts the span of characters to a <see cref="string"/> for
    /// all targeted .net frameworks.
    /// </summary>
    /// <param name="source">The source span.</param>
    /// <returns>A new string from the span.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string AsString(this ReadOnlySpan<char> source)
    {
#if NETLEGACY
        return new string(source.ToArray());
#else
        return source.ToString();
#endif
    }

    /// <summary>
    /// Determines whether the end of the span matches the specified value when compared using the
    /// <see cref="StringComparison.OrdinalIgnoreCase"/>.
    /// </summary>
    /// <param name="source">The source span.</param>
    /// <param name="value">The sequence to compare to the end of the source span.</param>
    /// <returns><see langword="true" /> when the span ends with the given value; otherwise, <see langword="false"/>.</returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool EndsWithIgnoreCase(this ReadOnlySpan<char> source, ReadOnlySpan<char> value)
        => source.EndsWith(value, StringComparison.OrdinalIgnoreCase);

    /// <summary>
    /// Determines whether the end of the string matches the specified value when compared using the
    /// <see cref="StringComparison.OrdinalIgnoreCase"/>.
    /// </summary>
    /// <param name="source">The source string.</param>
    /// <param name="value">The sequence to compare to the end of the source string.</param>
    /// <returns><see langword="true" /> when the string ends with the given value; otherwise, <see langword="false"/>.</returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool EndsWithIgnoreCase(this string? source, string value)
    {
        if (source is null)
            return false;

        return source.EndsWith(value, StringComparison.OrdinalIgnoreCase);
    }

    /// <summary>
    /// Determines whether the start of the span matches the specified value when compared using the
    /// <see cref="StringComparison.OrdinalIgnoreCase"/>.
    /// </summary>
    /// <param name="source">The source span.</param>
    /// <param name="value">The sequence to compare to the start of the source span.</param>
    /// <returns><see langword="true" /> when the span starts with the given value; otherwise, <see langword="false"/>.</returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool StartsWithIgnoreCase(this ReadOnlySpan<char> source, ReadOnlySpan<char> value)
        => source.StartsWith(value, StringComparison.OrdinalIgnoreCase);

    /// <summary>
    /// Determines whether the start of the string matches the specified value when compared using the
    /// <see cref="StringComparison.OrdinalIgnoreCase"/>.
    /// </summary>
    /// <param name="source">The source string.</param>
    /// <param name="value">The sequence to compare to the start of the source string.</param>
    /// <returns><see langword="true" /> when the string starts with the given value; otherwise, <see langword="false"/>.</returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool StartsWithIgnoreCase(this string? source, string value)
    {
        if (source is null)
            return false;

        return source.StartsWith(value, StringComparison.OrdinalIgnoreCase);
    }

    /// <summary>
    /// Indicates whether a specified value occurs within a read-only character span
    /// using the <see cref="StringComparison.OrdinalIgnoreCase"/>.
    /// </summary>
    /// <param name="source">The source span.</param>
    /// <param name="value">The value to seek within the source span.</param>
    /// <returns><see langword="true" /> when the span contains the given value; otherwise, <see langword="false"/>.</returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool ContainsIgnoreCase(this ReadOnlySpan<char> source, ReadOnlySpan<char> value)
        => source.Contains(value, StringComparison.OrdinalIgnoreCase);

    /// <summary>
    /// Indicates whether a specified value occurs within a string
    /// using the <see cref="StringComparison.OrdinalIgnoreCase"/>.
    /// </summary>
    /// <param name="source">The source string.</param>
    /// <param name="value">The value to seek within the source string.</param>
    /// <returns><see langword="true" /> when the string contains the given value; otherwise, <see langword="false"/>.</returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool ContainsIgnoreCase(this string? source, string value)
    {
        if (source is null)
            return false;

        return source.IndexOf(value, StringComparison.OrdinalIgnoreCase) > -1;
    }

    /// <summary>
    /// Indicates whether this span is equal to the given value using
    /// the <see cref="StringComparison.OrdinalIgnoreCase"/> comparison.
    /// </summary>
    /// <param name="source">The source span.</param>
    /// <param name="value">The value to test for equality.</param>
    /// <returns><see langword="true" /> when the span equals the value; otherwise, <see langword="false" />.</returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool EqualsIgnoreCase(this ReadOnlySpan<char> source, ReadOnlySpan<char> value)
    {
        return source.Equals(value, StringComparison.OrdinalIgnoreCase);
    }

    /// <summary>
    /// Determines whether the value on the left is equal to value
    /// right using <see cref="StringComparison.OrdinalIgnoreCase"/>
    /// by default.
    /// </summary>
    /// <param name="source">The source string.</param>
    /// <param name="right">The value to compare.</param>
    /// <param name="comparison">The string comparison type.</param>
    /// <returns><see langword="true" /> if the value is to the value on the right; otherwise, <see langword="false" />.</returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsEqualTo(
        this string? source,
        string? right,
        StringComparison comparison = StringComparison.OrdinalIgnoreCase)
    {
        if (ReferenceEquals(source, right))
            return true;
        return source?.Equals(right, comparison) == true;
    }

    /// <summary>
    /// Determines whether the value on the left is not equal to the value on the
    /// right using <see cref="StringComparison.OrdinalIgnoreCase"/>
    /// by default.
    /// </summary>
    /// <param name="source">The source string.</param>
    /// <param name="right">The value to compare.</param>
    /// <param name="comparison">The string comparison type.</param>
    /// <returns><see langword="true" /> if the value is to the value on the right; otherwise, <see langword="false" />.</returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNotEqualTo(
        this string? source,
        string? right,
        StringComparison comparison = StringComparison.OrdinalIgnoreCase)
    {
        if (ReferenceEquals(source, right))
            return false;

        return source?.Equals(right, comparison) == false;
    }

    public static string ScreamingSnakeCase(this string value)
    {
        var builder = StringBuilderCache.Acquire();
        var previous = char.MinValue;
        foreach (var c in value)
        {
            if (char.IsUpper(c) && builder.Length > 0 && previous != '_')
            {
                builder.Append('_');
            }

            if (c is '-' or ' ' or '_')
            {
                builder.Append('_');
                previous = '_';
                continue;
            }

            if (!char.IsLetterOrDigit(c))
                continue;

            builder.Append(char.ToUpperInvariant(c));
            previous = c;
        }

        return StringBuilderCache.GetStringAndRelease(builder);
    }

    public static string Hyphenate(this string value)
    {
        var builder = StringBuilderCache.Acquire();
        var previous = char.MinValue;
        foreach (var c in value)
        {
            if (char.IsUpper(c) && builder.Length > 0 && previous != '-')
            {
                builder.Append('-');
            }

            if (c is '_' or '-' or ' ')
            {
                builder.Append('-');
                previous = '-';
                continue;
            }

            if (!char.IsLetterOrDigit(c))
                continue;

            builder.Append(char.ToLowerInvariant(c));
            previous = c;
        }

        return StringBuilderCache.GetStringAndRelease(builder);
    }

    public static string Underscore(this string value)
    {
        var builder = StringBuilderCache.Acquire();
        var previous = char.MinValue;
        foreach (var c in value)
        {
            if (char.IsUpper(c) && builder.Length > 0 && previous != '_')
            {
                builder.Append('_');
            }

            if (c is '-' or ' ' or '_')
            {
                builder.Append('_');
                previous = '_';
                continue;
            }

            if (!char.IsLetterOrDigit(c))
                continue;

            builder.Append(char.ToLowerInvariant(c));
            previous = c;
        }

        return StringBuilderCache.GetStringAndRelease(builder);
    }

    public static Stream AsStream(this string value, Encoding? encoding = null)
    {
        encoding ??= Encoding.UTF8;
        return new MemoryStream(encoding.GetBytes(value));
    }
}