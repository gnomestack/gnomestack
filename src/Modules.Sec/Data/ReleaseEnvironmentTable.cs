namespace Gs.Modules.Sec.Data;

public class ReleaseEnvironmentTable : ReleaseEnvironmentTable<int>
{
}

public class ReleaseEnvironmentTable<TId>
    where TId : IEquatable<TId>
{
    public TId Id { get; set; } = default!;

    public string Key { get; set; } = null!;
}