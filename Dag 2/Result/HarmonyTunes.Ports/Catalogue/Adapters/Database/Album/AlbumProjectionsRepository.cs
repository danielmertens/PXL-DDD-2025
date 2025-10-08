using HarmonyTunes.Catalogue.Album.Projection.Interfaces;
using HarmonyTunes.Catalogue.Album.Projection.Models;

namespace HarmonyTunes.Ports.Catalogue.Adapters.Database.Album;

public class AlbumProjectionsRepository : IAlbumProjectionsRepository
{
    private readonly CatalogueContext _context;

    public AlbumProjectionsRepository(CatalogueContext context)
    {
        _context = context;
    }

    public void AddOrUpdateProjection(AlbumOverviewProjection projection)
    {
        var dbProjection = _context.AlbumOverviewProjection.Find(projection.Id);

        if (dbProjection == null)
        {
            _context.AlbumOverviewProjection.Add(projection);
        }
        else
        {
            _context.Entry(dbProjection).CurrentValues.SetValues(projection);
        }
    }

    public async Task Commit()
    {
        await _context.SaveChangesAsync();
    }
}
