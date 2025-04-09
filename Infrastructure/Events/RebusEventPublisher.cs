using Domain.Common;
using Rebus.Bus;

namespace Infrastructure.Events;

public class RebusEventPublisher : IEventPublisher
{
    private readonly IBus _bus;

    public RebusEventPublisher(IBus bus)
    {
        _bus = bus;
    }

    public async Task PublishAsync<TEvent>(TEvent @event) where TEvent : IDomainEvent
    {
        await _bus.Publish(@event);
    }
} 