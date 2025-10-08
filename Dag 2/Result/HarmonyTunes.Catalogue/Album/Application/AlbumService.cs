using HarmonyTunes.Catalogue.Album.Application.interfaces;
using HarmonyTunes.Catalogue.Album.Application.Models;
using HarmonyTunes.Catalogue.Album.Application.Notifications;
using HarmonyTunes.Catalogue.Album.Domain;
using HarmonyTunes.Catalogue.Album.Domain.ValueObjects;
using HarmonyTunes.Catalogue.Shared.Application.Interfaces;
using HarmonyTunes.Catalogue.Shared.Domain;
using HarmonyTunes.Domain.Core.Application;

namespace HarmonyTunes.Catalogue.Album.Application;

public class AlbumService :
    ApplicationService<AlbumAggregate, AlbumState, AlbumReference>,
    IAlbumService
{
    private readonly IMessagePublisher _messagePublisher;

    public AlbumService(IAlbumRepository albumRepository,
        IMessagePublisher messagePublisher)
        : base(albumRepository)
    {
        _messagePublisher = messagePublisher;
    }

    public async Task<AlbumReference> CreateAlbum(AlbumName albumName)
    {
        var id = await Add(agg => agg.Create(albumName));

        await _messagePublisher.Publish(new AlbumUpdatedNotification
        {
            AlbumReference = id.Key
        });

        return id;
    }

    public async Task PublishAlbum(AlbumReference albumReference)
    {
        await Update(albumReference, agg => agg.Publish());

        await _messagePublisher.Publish(new AlbumUpdatedNotification
        {
            AlbumReference = albumReference.Key
        });
    }

    public async Task UpdateAlbum(AlbumReference albumReference, AlbumDetails albumDetails)
    {
        await Update(albumReference, agg => agg.Update(albumDetails));
    }
}
