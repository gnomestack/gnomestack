using System.Text.Json.Serialization;

namespace Gnome.Sys;

public class PagedResponse<TValue>
{
    internal protected PagedResponse(IReadOnlyList<TValue>? value, Error? error = default)
    {
        this.Value = value;
        this.Error = error;
        this.IsOk = error == null;
    }

    protected internal PagedResponse(IEnumerable<TValue>? value, Error? error = default)
    {
        this.Value = value?.ToList();
        this.Error = error;
        this.IsOk = error == null;
        this.Next.Limit = this.Value?.Count ?? 0;
    }

    [JsonPropertyName("ok")]
    public bool IsOk { get; private set; }

    [JsonPropertyName("value")]
    public IReadOnlyList<TValue>? Value { get;  }

    [JsonPropertyName("error")]
    public Error? Error { get; }

    [JsonPropertyName("next")]
    public ContinuationToken Next { get; set; } = new();

    public static implicit operator PagedResponse<TValue>(List<TValue> value)
        => new(value, default!);

    public static implicit operator PagedResponse<TValue>(TValue[] value)
        => new(value, default!);

    public static implicit operator PagedResponse<TValue>(HashSet<TValue> value)
        => new(value, default!);

    public static implicit operator PagedResponse<TValue>(Error? error)
        => new(default!, error);

    public static implicit operator PagedResponse<TValue>(Exception exception)
        => new(default!, Error.Convert(exception));

    public static implicit operator List<TValue>(PagedResponse<TValue> response)
    {
        if (response.Value == null)
            return new();

        if (response.Value is List<TValue> list)
            return list;

        return response.Value.ToList();
    }

    public static implicit operator Error?(PagedResponse<TValue> response)
        => response.Error;

    public static implicit operator Task<PagedResponse<TValue>>(PagedResponse<TValue> response)
        => Task.FromResult(response);

    public static implicit operator ValueTask<PagedResponse<TValue>>(PagedResponse<TValue> response)
        => new(response);

    public static PagedResponse<TValue> Ok(IReadOnlyList<TValue> value)
        => new(value, default!);

    public static PagedResponse<TValue> Ok(IEnumerable<TValue> value)
        => new(value, default!);

    public static new PagedResponse<TValue> Fail(Error error)
        => new(default!, error);
}