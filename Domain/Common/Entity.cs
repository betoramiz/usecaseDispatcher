namespace Domain.Common;

public abstract class Entity
{
    protected readonly List<IDomainEvent> _events = [];


    public List<IDomainEvent> GetDomainEvents()
    {
        var copy = _events.ToList();
        
        _events.Clear();
        
        return copy;
    }
}