using HarmonyTunes.Catalogue.Album.Domain;
using HarmonyTunes.Catalogue.Shared.Domain;
using HarmonyTunes.Domain.Core.Application;

namespace HarmonyTunes.Catalogue.Album.Application.interfaces;

public interface IAlbumRepository
    : IRepository<AlbumAggregate, AlbumState, AlbumReference>
{
}