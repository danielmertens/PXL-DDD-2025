namespace HarmonyTunes.Catalogue.Artist.Domain.ValueObjects;

public record ArtistIdentification(LegalIdentification Legal, StageIdentification Stage)
{
}