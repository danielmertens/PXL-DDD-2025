using HarmonyTunes.Domain.Core;

namespace HarmonyTunes.Catalogue.Song.Domain;

public class SongState : AggregateState
{
    public override void Mutate(IDomainEvent evt)
    {
        throw new NotImplementedException();
    }
}
