using HarmonyTunes.Domain.Core;

namespace HarmonyTunes.Catalogue.Album.Domain.ValueObjects;

public class AlbumName : ValueObject
{
    public string Value { get; init; }

    public AlbumName(string name)
    {
        if (string.IsNullOrEmpty(name)) { throw new ArgumentException(nameof(name)); }
        Value = name;
    }

    protected override IEnumerable<object> GetValues()
    {
        yield return Value;
    }
}
