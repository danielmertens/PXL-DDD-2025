using HarmonyTunes.Domain.Core.Domain;

namespace HarmonyTunes.Catalogue.Shared.Domain;

public class Url : ValueObject
{
    public string Value { get; init; }
    public Url(string url)
    {
        if (string.IsNullOrEmpty(url)) { throw new ArgumentException(nameof(url)); }
        // Add more checks to verify this is a valid URL
        Value = url;
    }

    protected override IEnumerable<object> GetValues()
    {
        yield return Value;
    }
}
