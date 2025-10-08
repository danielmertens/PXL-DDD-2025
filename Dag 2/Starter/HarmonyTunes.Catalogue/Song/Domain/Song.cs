using HarmonyTunes.Catalogue.Shared.Domain;
using HarmonyTunes.Domain.Core;

namespace HarmonyTunes.Catalogue.Song.Domain;

public class Song : AggregateRoot<SongState, SongReference>
{
    protected Song(SongReference id) : base(id)
    {
    }

    protected Song(SongState currentState, SongReference id, int version) : base(currentState, id, version)
    {
    }
}
