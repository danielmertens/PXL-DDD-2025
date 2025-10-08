using HarmonyTunes.Catalogue.Album.Application.interfaces;
using HarmonyTunes.Catalogue.Album.Application.Notifications;
using Rebus.Handlers;

namespace HarmonyTunes.Ports.Catalogue.Adapters.Messaging.Consumers;

public class AlbumUpdatedNotificationHandler
    : IHandleMessages<AlbumUpdatedNotification>
{
    private readonly IAlbumQueryService _albumQueryService;

    public AlbumUpdatedNotificationHandler(IAlbumQueryService albumQueryService)
    {
        _albumQueryService = albumQueryService;
    }

    public async Task Handle(AlbumUpdatedNotification message)
    {
        var albumName = (await _albumQueryService.GetById(message.AlbumReference)).Name;
        Console.WriteLine($"Album {albumName} updated.");
    }
}
