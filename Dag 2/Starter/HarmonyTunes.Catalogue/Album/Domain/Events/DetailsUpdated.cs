using HarmonyTunes.Catalogue.Album.Domain.ValueObjects;
using HarmonyTunes.Catalogue.Shared.Domain;
using HarmonyTunes.Domain.Core;

namespace HarmonyTunes.Catalogue.Album.Domain.Events;

public class DetailsUpdated : DomainEvent
{
    public AlbumDescription Description { get; init; }
    public Url BackgroundImageUrl { get; init; }
    public Year PublicationYear { get; init; }

    protected override IEnumerable<object> GetValues()
    {
        yield return Description;
        yield return BackgroundImageUrl;
        yield return PublicationYear;
    }
}
