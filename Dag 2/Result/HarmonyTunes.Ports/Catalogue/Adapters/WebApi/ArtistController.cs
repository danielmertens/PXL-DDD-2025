using HarmonyTunes.Catalogue.Artist.Application.Interfaces;
using HarmonyTunes.Catalogue.Artist.Domain.ValueObjects;
using HarmonyTunes.Catalogue.Shared.Domain;
using Microsoft.AspNetCore.Mvc;

namespace HarmonyTunes.Ports.Catalogue.Adapters.WebApi;

public class ArtistController
{
    public static void RegisterControllers(WebApplication app)
    {
        app.MapPost("/api/artist/create", async (ArtistIdentification identification, IArtistService service) =>
        {
            return await service.Create(identification);
        });

        app.MapPost("/api/artist/{artistRef:guid}/billing/update", async (Guid artistRef, [FromBody] BillingInfo billingInfo, IArtistService service) =>
        {
            await service.UpdateBillingInfo(new ArtistReference(artistRef), billingInfo);
        });
    }
}
