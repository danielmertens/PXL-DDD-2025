namespace HarmonyTunes.Ports.Catalogue.Models;

public class CreateSongDto
{
    public Guid AlbumReference { get; set; }
    public string Name { get; set; }
}
