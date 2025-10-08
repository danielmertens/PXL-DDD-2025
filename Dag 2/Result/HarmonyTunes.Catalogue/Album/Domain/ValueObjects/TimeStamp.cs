using HarmonyTunes.Domain.Core.Domain;

namespace HarmonyTunes.Catalogue.Album.Domain.ValueObjects;

public class TimeStamp : ValueObject
{
    public DateTime Value { get; set; }
    public TimeStamp(DateTime timestamp)
    {

        Value = timestamp;

    }

    protected override IEnumerable<object> GetValues()
    {
        yield return Value;
    }
}
