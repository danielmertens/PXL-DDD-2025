using HarmonyTunes.Catalogue.Album.Application.Models;
using HarmonyTunes.Catalogue.Album.Domain.Events;
using HarmonyTunes.Catalogue.Album.Domain.Exceptions;
using HarmonyTunes.Catalogue.Album.Domain.ValueObjects;
using HarmonyTunes.Catalogue.Shared.Domain;
using HarmonyTunes.Domain.Core;

namespace HarmonyTunes.Catalogue.Album.Domain;

public class AlbumAggregate : AggregateRoot<AlbumState, AlbumReference>
{
    public AlbumAggregate(AlbumReference id) : base(id)
    {
    }

    public AlbumAggregate(AlbumState currentState, AlbumReference id, int version) : base(currentState, id, version)
    {
    }

    public void Create(AlbumName albumName)
    {
        if (CurrentState.Status != AlbumStatus.Unknown)
            throw new AlbumAlreadyCreated();

        RaiseEvent(new AlbumCreated
        {
            AlbumName = albumName
        });
    }

    public void Update(AlbumDetails albumDetails)
    {
        RaiseEvent(new DetailsUpdated
        {
            Description = albumDetails.Description,
            BackgroundImageUrl = albumDetails.BackgroundImageUrl,
            PublicationYear = albumDetails.PublicationYear
        });
    }
}
