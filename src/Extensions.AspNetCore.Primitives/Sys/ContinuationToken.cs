using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Gnome.Sys;

[JsonConverter(typeof(ContinuationTokenJsonConverter))]
public class ContinuationToken
{
    /// <summary>
    /// Gets or sets the offset where the next page should start.
    /// </summary>
    public int Offset { get; set; }

    /// <summary>
    /// Gets or sets the number of items for a page.
    /// </summary>
    public int Limit { get; set; }

    /// <summary>
    /// Gets or sets the total number of items.
    /// </summary>
    public int Total { get; set; }

    public static ContinuationToken Parse(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return new();

        var bytes = Convert.FromBase64String(value);
        var parts = Encoding.UTF8.GetString(bytes).Split(':');
        if (parts.Length != 3)
            return new();

        return new ContinuationToken
        {
            Offset = int.Parse(parts[0]),
            Limit = int.Parse(parts[1]),
            Total = int.Parse(parts[2]),
        };
    }

    public override string ToString()
    {
        var size = this.Offset * this.Limit;
        if (size >= this.Total)
            return string.Empty;

        var bytes = Encoding.UTF8.GetBytes($"{this.Offset}:{this.Limit}:{this.Total}");
        return Convert.ToBase64String(bytes);
    }
}

public class ContinuationTokenJsonConverter : JsonConverter<ContinuationToken>
{
    public override ContinuationToken Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.String)
            return new ContinuationToken();

        return ContinuationToken.Parse(reader.GetString() ?? string.Empty);
    }

    public override void Write(Utf8JsonWriter writer, ContinuationToken value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}