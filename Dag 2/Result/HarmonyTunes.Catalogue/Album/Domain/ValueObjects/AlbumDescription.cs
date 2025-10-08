using HarmonyTunes.Domain.Core.Domain;

namespace HarmonyTunes.Catalogue.Album.Domain.ValueObjects;

public class AlbumDescription : ValueObject
{
    public string Value { get; init; }

    public AlbumDescription(string description)
    {
        if (string.IsNullOrEmpty(description)) { throw new ArgumentException(nameof(description)); }
        Value = description;
    }

    protected override IEnumerable<object> GetValues()
    {
        yield return Value;
    }
}
