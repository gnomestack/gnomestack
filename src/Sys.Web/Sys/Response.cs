using System.Text.Json.Serialization;

namespace Gnome.Sys;

public class Response
{
    public Response(Error? error = default)
    {
        this.IsOk = error == null;
        this.Error = error;
    }

    [JsonPropertyName("ok")]
    public bool IsOk { get; private set; }

    [JsonPropertyName("error")]
    public Error? Error { get; }

    public static implicit operator Response(Error? error)
        => new(error);

    public static implicit operator Error?(Response response)
        => response.Error;

    public static implicit operator Task<Response>(Response response)
        => Task.FromResult(response);

    public static implicit operator ValueTask<Response>(Response response)
        => new(response);

    public static new Response Ok()
        => new();

    public static Response<TValue> Ok<TValue>(TValue value)
        => new(value);

    public static Response<TValue, TError> Ok<TValue, TError>(TValue value)
        => new(value);

    public static new Response Fail(Error error)
        => new(error);

    public static new Response<TValue> Fail<TValue>(Error error)
        => new(default!, error);

    public static Response<TValue, TError> Fail<TValue, TError>(TError error)
        => new(default!, error);
}