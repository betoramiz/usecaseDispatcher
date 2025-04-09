using Domain.Todo;
using Rebus.Handlers;

namespace Application.UseCases.Todo.Events;

public class TodoCreatedEventHandler: IHandleMessages<CreatedEvent> 
{
    public async Task Handle(CreatedEvent message)
    {
        await Task.CompletedTask;
    }
} 