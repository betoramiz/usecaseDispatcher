namespace Domain.Common;

public interface IEventPublisher
{
    Task PublishAsync<TEvent>(TEvent @event) where TEvent : IDomainEvent;
} 