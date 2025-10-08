using HarmonyTunes.Catalogue.Shared.Application.Interfaces;
using Rebus.Bus;

namespace HarmonyTunes.Ports.Catalogue.Adapters.Messaging;

public class MessagePublisher : IMessagePublisher
{
    private readonly IBus _bus;

    public MessagePublisher(IBus bus)
    {
        _bus = bus;
    }

    public async Task Publish<T>(T notification)
        where T : INotification
    {
        await _bus.Send(notification);
    }
}
