using HarmonyTunes.Domain.Core.Domain;

namespace HarmonyTunes.Catalogue.Album.Domain.ValueObjects;

public class Year : ValueObject
{
    public int Value { get; init; }

    public Year(int year)
    {
        if (year < 1900) throw new ArgumentOutOfRangeException(nameof(year));
        Value = year;
    }

    protected override IEnumerable<object> GetValues()
    {
        yield return Value;
    }
}
