using HarmonyTunes.Catalogue.Album.Domain.ValueObjects;
using HarmonyTunes.Domain.Core.Domain;

namespace HarmonyTunes.Catalogue.Album.Domain.Events;

public class AlbumCreated : DomainEvent
{
    public AlbumName AlbumName { get; set; }

    protected override IEnumerable<object> GetValues()
    {
        yield return AlbumName;
    }
}