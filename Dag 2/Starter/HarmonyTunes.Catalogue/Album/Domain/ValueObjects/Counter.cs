using HarmonyTunes.Domain.Core;

namespace HarmonyTunes.Catalogue.Album.Domain.ValueObjects;

public class Counter : ValueObject
{
    public long Value { get; set; }

    public Counter(long count)
    {
        if (count < 0) throw new ArgumentOutOfRangeException(nameof(count));
        Value = count;
    }

    public Counter Increment()
    {
        return new Counter(Value++);
    }

    protected override IEnumerable<object> GetValues()
    {
        yield return Value;
    }
}
