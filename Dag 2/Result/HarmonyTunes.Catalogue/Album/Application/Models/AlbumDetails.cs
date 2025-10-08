using HarmonyTunes.Catalogue.Album.Domain.ValueObjects;
using HarmonyTunes.Catalogue.Shared.Domain;

namespace HarmonyTunes.Catalogue.Album.Application.Models;

public class AlbumDetails
{
    public AlbumDescription Description { get; init; }
    public Url BackgroundImageUrl { get; init; }
    public Year PublicationYear { get; init; }
    public ArtistReference Artist { get; init; }
}
