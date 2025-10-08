using HarmonyTunes.Catalogue.Album.Domain.ValueObjects;
using HarmonyTunes.Catalogue.Shared.Domain;
using HarmonyTunes.Domain.Core.Domain;

namespace HarmonyTunes.Catalogue.Album.Domain.Events;

public class DetailsUpdated : DomainEvent
{
    public AlbumDescription Description { get; init; }
    public Url BackgroundImageUrl { get; init; }
    public Year PublicationYear { get; init; }
    public ArtistReference Artist { get; init; }

    protected override IEnumerable<object> GetValues()
    {
        yield return Description;
        yield return BackgroundImageUrl;
        yield return PublicationYear;
        yield return Artist;
    }
}
