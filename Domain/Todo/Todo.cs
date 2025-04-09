using Domain.Common;

namespace Domain.Todo;

public class Todo
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public Todo() { }

    private Todo(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }

    public static Todo Create(string name)
    {
        return new Todo(name);
    }
}