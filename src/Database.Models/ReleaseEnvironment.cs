namespace Gs.Database.Models;

public class ReleaseEnvironment : ReleaseEnvironment<int>
{
}

public class ReleaseEnvironment<TId>
    where TId : IEquatable<TId>
{
    public TId Id { get; set; } = default!;

    public string Key { get; set; } = null!;
}