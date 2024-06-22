using System.Text.Json.Serialization;

namespace Gnome.Sys;

public class Response<TValue>
{
    public Response(TValue? value = default, Error? error = default)
    {
        this.Value = value!;
        this.Error = error!;
        this.IsOk = error == null;
    }

    [JsonPropertyName("ok")]
    public bool IsOk { get; private set; }

    [JsonPropertyName("value")]
    public TValue Value { get;  }

    [JsonPropertyName("error")]
    public Error? Error { get; }

    public static implicit operator Response<TValue>(TValue? value)
        => new(value, default!);

    public static implicit operator Response<TValue>(Error? error)
        => new(default!, error);

    public static implicit operator Response<TValue>(Exception exception)
        => new(default!, Error.Convert(exception));

    public static implicit operator Response<TValue>((TValue?, Error?) response)
        => new(response.Item1, response.Item2);

    public static implicit operator TValue(Response<TValue> response)
        => response.Value;

    public static implicit operator Error?(Response<TValue> response)
        => response.Error;

    public static implicit operator Task<Response<TValue>>(Response<TValue> response)
        => Task.FromResult(response);

    public static implicit operator ValueTask<Response<TValue>>(Response<TValue> response)
        => new(response);

    public static new Response<TValue> Ok(TValue value)
        => new(value, default!);

    public static new Response<TValue> Fail(Error error)
        => new(default!, error);
}