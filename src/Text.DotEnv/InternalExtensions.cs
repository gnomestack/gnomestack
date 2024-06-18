using System;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Gnome;

public static class InternalExtensions
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

    /// <summary>
    ///    Converts the value of a <see cref="StringBuilder" /> to a <see cref="char" /> array.
    /// </summary>
    /// <param name="builder">The string builder.</param>
    /// <returns>An array with all the characters of the string builder.</returns>
    /// <exception cref="ArgumentNullException">Thrown when builder is null.</exception>
    public static char[] ToArray(this StringBuilder builder)
    {
        if (builder is null)
            throw new ArgumentNullException(nameof(builder));

        var set = new char[builder.Length];
        builder.CopyTo(
            0,
            set,
            0,
            set.Length);
        return set;
    }
}