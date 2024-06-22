using System.Text.Json.Serialization;

namespace Gnome.Sys;

public class PagedResponse
{
    internal protected PagedResponse(Error? error = default)
    {
        this.IsOk = error == null;
        this.Error = error;
    }

    [JsonPropertyName("ok")]
    public bool IsOk { get; private set; }

    [JsonPropertyName("error")]
    public Error? Error { get; }

    [JsonPropertyName("next")]
    public ContinuationToken Next { get; set; } = new();

    public static implicit operator PagedResponse(Error error)
        => new(error);

    public static implicit operator Error?(PagedResponse response)
        => response.Error;

    public static implicit operator Task<PagedResponse>(PagedResponse response)
        => Task.FromResult(response);

    public static implicit operator ValueTask<PagedResponse>(PagedResponse response)
        => new(response);

    public static PagedResponse Ok()
        => new();

    public static PagedResponse<TValue> Ok<TValue>(IReadOnlyList<TValue> value)
        => new(value);

    public static PagedResponse<TValue> Ok<TValue>(IEnumerable<TValue> value)
        => new(value);

    public static PagedResponse Fail(Error error)
        => new(error);

    public static PagedResponse<TValue> Fail<TValue>(Error error)
        => new(null, error);
}