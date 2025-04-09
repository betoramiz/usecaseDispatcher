using Domain.Common;

namespace Domain.Todo;

public class CreatedEvent : DomainEvent
{
    public string Title { get; }
    public DateTime CreatedAt { get; }

    public CreatedEvent(string title)
    {
        Title = title;
        CreatedAt = DateTime.UtcNow;
    }
} 