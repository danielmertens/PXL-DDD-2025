using HarmonyTunes.Catalogue.Shared.Domain;
using HarmonyTunes.Catalogue.Song.Application.Interfaces;
using HarmonyTunes.Catalogue.Song.Domain;
using HarmonyTunes.Catalogue.Song.Domain.ValueObjects;
using HarmonyTunes.Domain.Core.Application;

namespace HarmonyTunes.Catalogue.Song.Application;

public class SongService
    : ApplicationService<SongAggregate, SongState, SongReference>,
    ISongService
{
    public SongService(ISongRepository repository)
        : base(repository)
    {
    }

    public async Task<SongReference> Create(AlbumReference albumReference,
        SongName name)
    {
        return await Add(agg => agg.Create(albumReference, name));
    }
}
