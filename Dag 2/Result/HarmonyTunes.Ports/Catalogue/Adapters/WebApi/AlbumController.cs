using HarmonyTunes.Catalogue.Album.Application.interfaces;
using HarmonyTunes.Catalogue.Album.Application.Models;
using HarmonyTunes.Catalogue.Album.Application.Notifications;
using HarmonyTunes.Catalogue.Album.Domain.ValueObjects;
using HarmonyTunes.Catalogue.Shared.Domain;
using HarmonyTunes.Ports.Catalogue.Models;
using Rebus.Bus;

namespace HarmonyTunes.Ports.Catalogue.Adapters.WebApi;

public static class AlbumController
{
    public static void RegisterControllers(WebApplication app)
    {
        app.MapPost("/api/test", async (IBus bus) =>
        {
            await bus.Send(new AlbumUpdatedNotification());
        });

        app.MapPost("/api/albums/create", async (CreateAlbumDto dto, IAlbumService albumService) =>
        {
            var albumId = await albumService.CreateAlbum(new AlbumName(dto.Name));
            return albumId.Key;
        });

        app.MapPost("/api/albums/update", async (AlbumDetailsDto dto, IAlbumService albumService) =>
        {
            await albumService.UpdateAlbum(
                new AlbumReference(dto.AlbumReference),
                new AlbumDetails
                {
                    Description = new AlbumDescription(dto.Description),
                    BackgroundImageUrl = new Url(dto.BackgroundImageUrl),
                    PublicationYear = new Year(dto.Year),
                    Artist = new ArtistReference(dto.ArtistReference)
                });
        });

        app.MapPost("/api/albums/publish/{albumReference:guid}", async (Guid albumReference, IAlbumService albumService) =>
        {
            await albumService.PublishAlbum(new AlbumReference(albumReference));
        });

        app.MapGet("/api/albums", async (IAlbumQueryService queryService) =>
        {
            return (await queryService.GetAll()).ToArray();
        });

        app.MapGet("/api/albums/{albumReference:guid}", async (Guid albumReference, IAlbumQueryService queryService) =>
        {
            return await queryService.GetById(albumReference);
        });
    }
}
