namespace HarmonyTunes.Ports;

public class AlbumDetailsDto
{
    public Guid AlbumReference { get; set; }
    public string Description { get; set; }
    public string BackgroundImageUrl { get; set; }
    public int Year { get; set; }
}
