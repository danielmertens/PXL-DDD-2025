using HarmonyTunes.Catalogue.Album.Application.Models;
using HarmonyTunes.Catalogue.Album.Domain.ValueObjects;
using HarmonyTunes.Catalogue.Shared.Domain;

namespace HarmonyTunes.Catalogue.Album.Application.interfaces;

public interface IAlbumService
{
    Task<AlbumReference> CreateAlbum(AlbumName albumName);
    Task PublishAlbum(AlbumReference albumReference);
    Task UpdateAlbum(AlbumReference albumReference, AlbumDetails albumDetails);
}