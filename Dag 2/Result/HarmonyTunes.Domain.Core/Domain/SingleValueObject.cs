namespace HarmonyTunes.Domain.Core.Domain;

public class SingleValueObject<T> : ValueObject
{
    public T Value { get; }

    public SingleValueObject(T value)
    {
        Value = value;
    }

    protected override IEnumerable<object> GetValues()
    {
        yield return Value;
    }
}
