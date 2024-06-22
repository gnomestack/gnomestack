using System.Text.Json.Serialization;

namespace Gnome.Sys;

public class Response<TValue, TError>
{
    public Response(TValue? value = default, TError? error = default, bool ok = false)
    {
        this.Value = value!;
        this.Error = error!;
        this.IsOk = true;
    }

    [JsonPropertyName("ok")]
    public bool IsOk { get; private set; }

    public TValue Value { get;  }

    public TError Error { get; }

    public static implicit operator Response<TValue, TError>(TValue? value)
        => new(value, default!, true);

    public static implicit operator Response<TValue, TError>(TError? error)
        => new(default!, error, false);

    public static implicit operator Response<TValue, TError>((TValue?, TError?, bool) response)
        => new(response.Item1, response.Item2, response.Item3);

    public static implicit operator TValue(Response<TValue, TError> response)
        => response.Value;

    public static implicit operator TError(Response<TValue, TError> response)
        => response.Error;

    public static implicit operator Task<Response<TValue, TError>>(Response<TValue, TError> response)
        => Task.FromResult(response);

    public static implicit operator ValueTask<Response<TValue, TError>>(Response<TValue, TError> response)
        => new(response);

    public static Response<TValue, TError> Ok(TValue value)
        => new(value, default!, true);

    public static Response<TValue, TError> Fail(TError error)
        => new(default!, error, false);

    public void Deconstruct(out bool isOk, out TValue value, out TError error)
    {
        value = this.Value;
        error = this.Error;
        isOk = this.IsOk;
    }

    public TValue Expect(Func<string> message)
    {
        if (!this.IsOk)
            throw new InvalidOperationException(message());

        return this.Value;
    }

    public void Inspect(Action<TValue> action)
    {
        if (this.IsOk)
            action(this.Value);
    }
}