
using HarmonyTunes.Catalogue.Album.Application.Notifications;
using HarmonyTunes.Catalogue.Shared.Application.Interfaces;
using HarmonyTunes.Ports.Catalogue.Adapters.Messaging.Consumers;
using Rebus.Config;
using Rebus.Routing.TypeBased;

namespace HarmonyTunes.Ports.Catalogue.Adapters.Messaging;

public class RegisterMessenger
{
    public static void Register(IServiceCollection services)
    {
        var queue = "HarmonyTunes.Catalogue.In";
        services.AddRebus(configure => configure
            .Transport(t => t.UseRabbitMq("amqp://localhost", queue))
            .Routing(r => r.TypeBased().Map<AlbumUpdatedNotification>(queue)));

        services.AutoRegisterHandlersFromAssemblyOf<AlbumUpdatedNotificationHandler>();

        services.AddScoped<IMessagePublisher, MessagePublisher>();
    }
}
