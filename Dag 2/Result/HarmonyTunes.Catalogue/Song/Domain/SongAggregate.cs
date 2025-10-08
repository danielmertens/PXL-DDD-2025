using HarmonyTunes.Catalogue.Shared.Domain;
using HarmonyTunes.Catalogue.Song.Domain.Events;
using HarmonyTunes.Catalogue.Song.Domain.ValueObjects;
using HarmonyTunes.Domain.Core.Domain;

namespace HarmonyTunes.Catalogue.Song.Domain;

public class SongAggregate : AggregateRoot<SongState, SongReference>
{
    public SongAggregate(SongReference id) : base(id)
    {
    }

    public SongAggregate(SongState currentState, SongReference id, int version) : base(currentState, id, version)
    {
    }

    public void Create(AlbumReference albumReference, SongName name)
    {
        RaiseEvent(new SongCreated
        {
            AlbumId = albumReference,
            Name = name
        });
    }
}
