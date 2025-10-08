using HarmonyTunes.Catalogue.Album.Domain.Events;
using HarmonyTunes.Catalogue.Album.Domain.ValueObjects;
using HarmonyTunes.Catalogue.Shared.Domain;
using HarmonyTunes.Domain.Core;

namespace HarmonyTunes.Catalogue.Album.Domain;

public class AlbumState : AggregateState
{
    public AlbumName Name { get; private set; }
    public AlbumDescription? Description { get; private set; }
    public Url? BackgroundImageUrl { get; private set; }
    public Year? PublicationYear { get; private set; }
    public Counter Likes { get; private set; } = new Counter(0);

    public AlbumStatus Status { get; private set; } = AlbumStatus.Unknown;

    public override void Mutate(IDomainEvent evt)
    {
        switch (evt)
        {
            case AlbumCreated albumCreated:
                When(albumCreated);
                break;
            case DetailsUpdated detailsUpdated:
                When(detailsUpdated);
                break;
        }
    }

    public void When(AlbumCreated evt)
    {
        Name = evt.AlbumName;
        Status = AlbumStatus.Unpublished;
    }

    public void When(DetailsUpdated evt)
    {
        Description = evt.Description;
        BackgroundImageUrl = evt.BackgroundImageUrl;
        PublicationYear = evt.PublicationYear;
    }
}
