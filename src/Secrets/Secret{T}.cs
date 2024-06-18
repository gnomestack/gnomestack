using System.Buffers;

namespace Gnome.Secrets;

/// <summary>
/// Represents a secret value that is stored in memory. It does not guarantee that
/// the value is encrypted or securely stored. It does help avoid accidental exposure
/// to logs or other diagnostic information that isn't a memory dump.
/// </summary>
/// <typeparam name="T">The unmanaged type.</typeparam>
public sealed class Secret<T> : IDisposable
    where T : unmanaged
{
    private readonly IMemoryOwner<T> owner;

    public Secret(ReadOnlySpan<T> value)
        : this(value, true)
    {
    }

    internal Secret(ReadOnlySpan<T> value, bool encrypt)
    {
        // TODO: use chacha or something else for encrypting secrets.
        this.Length = value.Length;
        this.owner = MemoryPool<T>.Shared.Rent(this.Length);
        value.CopyTo(this.owner.Memory.Span);
    }

    public int Length { get; }

    public T[] Reveal()
        => this.owner.Memory.Span[..this.Length].ToArray();

    public int RevealInto(Span<T> destination)
    {
        var max = Math.Min(this.Length, destination.Length);
        this.owner.Memory.Span[..max].CopyTo(destination);
        return this.Length;
    }

#if !NETLEGACY
    public void Inspect<TState>(TState state, ReadOnlySpanAction<T, TState> action)
    {
        var span = this.owner.Memory.Span[..this.Length];
        action(span, state);
    }
#endif

    public void Dispose()
    {
        this.owner.Dispose();
    }

    public override string ToString()
        => "********";
}