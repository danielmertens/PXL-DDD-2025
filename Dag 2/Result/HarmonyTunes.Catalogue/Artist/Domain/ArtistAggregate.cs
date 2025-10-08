using HarmonyTunes.Catalogue.Artist.Domain.Events;
using HarmonyTunes.Catalogue.Artist.Domain.ValueObjects;
using HarmonyTunes.Catalogue.Shared.Domain;
using HarmonyTunes.Domain.Core.Domain;

namespace HarmonyTunes.Catalogue.Artist.Domain;

public class ArtistAggregate : AggregateRoot<ArtistState, ArtistReference>
{
    public ArtistAggregate(ArtistReference id) : base(id)
    {
    }

    public ArtistAggregate(ArtistReference id, IEnumerable<IDomainEvent> events) : base(id, events)
    {
    }

    public void Create(ArtistIdentification artistIdentification)
    {
        RaiseEvent(new ArtistCreated
        {
            ArtistIdentification = artistIdentification
        });
    }

    public void UpdateBilling(BillingInfo billingInfo)
    {
        RaiseEvent(new BillingInfoUpdated
        {
            BillingInfo = billingInfo
        });
    }
}
